using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public delegate void OnInventoryChangeCallback();
    public OnInventoryChangeCallback onInventoryChange;

    [SerializeField] private InventoryDisplay display;

    public List<InventoryElement> inventoryElements = new List<InventoryElement>();

    [SerializeField] private Item[] testItems;

    //For testing only
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem(testItems[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddItem(testItems[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddItem(testItems[2]);
        }
    }

    public bool AddItem(Item newItem, int count = 1)
    {
        if (!newItem.CanStack || !Contains(newItem))
        {
            var node = display.FindOpenNode(newItem.Width, newItem.Height, newItem.CanRotate);
            if (node != null)
            {
                AddElement(newItem, count, node);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            //Currently this does not account for max stack size
            FindSlot(newItem).count += count;
            onInventoryChange?.Invoke();
            return true;
        }
    }

    private void AddElement(Item item, int count, GridNode node)
    {
        var go = Instantiate(item.UIElementPrefab, display.GetGridPosition(node.x, node.y), Quaternion.identity);
        go.transform.SetParent(display.Origin);
        
        var element = go.GetComponent<InventoryElement>();
        element.SetProperties(item, node.x, node.y, count);

        inventoryElements.Add(element);
        element.onElementBeginDrag += OnElementBeginDrag;
        element.onElementEndDrag += OnElementEndDrag;

        display.ToggleNodesOccupied(node, item.Width, item.Height, true);

        onInventoryChange?.Invoke();
    }

    public void RemoveItem(Item oldItem, int count = 1)
    {
        Debug.Assert(Contains(oldItem));

        var slot = FindSlot(oldItem);
        if (count >= slot.count)
        {
            Destroy(slot.gameObject);
            inventoryElements.Remove(slot);
        }
        else
        {
            slot.count -= count;
        }   

        onInventoryChange?.Invoke();
    }

    private void RemoveElement()
    {

    }

    public bool Contains(Item item)
    {
        if (FindSlot(item) != null)
        {
            return true;
        }

        return false;
    }

    public InventoryElement FindSlot(Item item)
    {
        for (int i = 0; i < inventoryElements.Count; i++)
        {
            if (inventoryElements[i].item = item)
            {
                return inventoryElements[i];
            }
        }

        return null;
    }

    private int previousX;
    private int previousY;

    private void OnElementBeginDrag(InventoryElement element)
    {
        var node = display.GetNode(element.gridX, element.gridY);
        previousX = node.x;
        previousY = node.y;

        display.ToggleNodesOccupied(node, element.item.Width, element.item.Height, false);
    }

    private void OnElementEndDrag(InventoryElement element)
    {
        int x = Mathf.RoundToInt(element.Rect.localPosition.x * 0.01f);
        int y = Mathf.RoundToInt(element.Rect.localPosition.y * 0.01f);
        var newNode = display.GetNode(x, y);

        if (newNode != null && display.OnValidateNewPosition(newNode, element.item.Width, element.item.Height))
        {
            //Set new position
            display.ToggleNodesOccupied(newNode, element.item.Width, element.item.Height, true);
            element.Rect.localPosition = new Vector2(newNode.x * 100, newNode.y * 100);
            element.gridX = newNode.x;
            element.gridY = newNode.y;
        }
        else
        {
            ReturnToPreviousPosition(element);
        }
    }

    private void ReturnToPreviousPosition(InventoryElement element)
    {
        var oldNode = display.GetNode(previousX, previousY);
        display.ToggleNodesOccupied(oldNode, element.item.Width, element.item.Height, true);
        element.Rect.localPosition = new Vector2(oldNode.x * 100, oldNode.y * 100);
        element.gridX = oldNode.x;
        element.gridY = oldNode.y;
    }
}