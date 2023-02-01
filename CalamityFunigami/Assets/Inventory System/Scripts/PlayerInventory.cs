using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    public delegate void OnInventoryChangeCallback();
    public OnInventoryChangeCallback onInventoryChange;

    private InventoryDisplay display;

    private List<InventoryElement> _inventoryElements;
    public List<InventoryElement> InventoryElements => _inventoryElements;

    private int previousX; //hold the previous grid location of items being dragged
    private int previousY;

    private void Start()
    {
        _inventoryElements = new List<InventoryElement>();

        //If we get some sort of UI Manager, can just cache it and grab from there
        display = GameObject.FindObjectOfType<Canvas>().GetComponent<InventoryDisplay>();
    }

    public void ToggleInventoryDisplay()
    {
        display.ToggleDisplay();
    }

    //Add new items to the player's inventory
    //The return int is for the event that the player attempts to move more items to their inventory than they can carry
    //Use it to determine the number of remaining items in the container after the player takes them
    public int AddItem(Item newItem, int count = 1)
    {
        //Run through existing elements while they're below capacity
        var openElements = FindOpenElements(newItem);
        for (int i = 0; i < openElements.Count; i++)
        {
            //Max out the amount to add at the element's max stack count or the remaining count
            int amountToAdd = openElements[i].item.MaxStackCount - openElements[i].count;
            amountToAdd = Mathf.Clamp(amountToAdd, 0, count);

            openElements[i].SetItemCount(openElements[i].count + amountToAdd);
            count -= amountToAdd;

            if (count <= 0)
            {
                return 0;
            }
        }

        //remaining count is still greater than zero, need to create new elements
        if (count > 0)
        {
            //Attempt to create a number of elements necessary for the current count
            float newCount = count; //Converting this to a float because ints don't like to be divided
            int amountToCreate = Mathf.CeilToInt(newCount / newItem.MaxStackCount);

            for (int i = 0; i < amountToCreate; i++)
            {
                var node = display.FindOpenNode(newItem.Width, newItem.Height, newItem.CanRotate);
                if (node != null)
                {
                    int maxCount = Mathf.Clamp(count, 0, newItem.MaxStackCount);
                    AddElement(newItem, maxCount, node);
                    count -= maxCount;

                    if (count <= 0)
                    {
                        return 0;
                    }
                }
            }
        }

        Debug.Log(count + " remaining");
        return count;
    }

    private void AddElement(Item item, int count, GridNode node)
    {
        var go = Instantiate(item.UIElementPrefab, display.GetGridPosition(node.x, node.y), Quaternion.identity);
        go.transform.SetParent(display.Origin);

        var element = go.GetComponent<InventoryElement>();
        element.SetProperties(item, node.x, node.y, count);

        _inventoryElements.Add(element);
        element.onItemUsed += OnItemUsed;
        element.onElementBeginDrag += OnElementBeginDrag;
        element.onElementEndDrag += OnElementEndDrag;

        display.ToggleNodesOccupied(node, item.Width, item.Height, true);

        onInventoryChange?.Invoke();
    }

    private void RemoveItem(InventoryElement element, int count = 1)
    {
        //Removing some items from the stack
        if (element.count > count)
        {
            element.SetItemCount(element.count - count);
        }
        //Remove the stack
        else
        {
            RemoveElement(element);
        }

        onInventoryChange?.Invoke();
    }

    public void RemoveItem(Item oldItem, int count = 1)
    {
        Debug.Assert(Contains(oldItem));

        var element = FindElement(oldItem);

        //Removing some items from the stack
        if (element.count > count)
        {
            element.SetItemCount(element.count - count);
        }
        //Removing the stack
        else if (element.count == count)
        {
            RemoveElement(element);
        }
        //Removing multiple stacks
        else
        {
            RemoveItemsRecursively(oldItem, count);
        }

        onInventoryChange?.Invoke();
    }

    private void RemoveItemsRecursively(Item oldItem, int count)
    {
        var elementList = FindElements(oldItem);

        for (int i = 0; i < elementList.Count; i++)
        {
            int amountToRemove = elementList[i].count;
            amountToRemove = Mathf.Clamp(amountToRemove, 0, count);

            elementList[i].SetItemCount(elementList[i].count - amountToRemove);
            count -= amountToRemove;

            if (count <= 0)
            {
                break;
            }
        }
    }

    private void RemoveElement(InventoryElement element)
    {
        element.onItemUsed -= OnItemUsed;
        element.onElementBeginDrag -= OnElementBeginDrag;
        element.onElementEndDrag -= OnElementEndDrag;
        _inventoryElements.Remove(element);
        Destroy(element.gameObject);
    }

    public bool Contains(Item item)
    {
        if (FindElement(item) != null)
        {
            return true;
        }

        return false;
    }

    public InventoryElement FindElement(Item item)
    {
        for (int i = 0; i < _inventoryElements.Count; i++)
        {
            if (_inventoryElements[i].item == item)
            {
                return _inventoryElements[i];
            }
        }

        return null;
    }

    private List<InventoryElement> FindElements(Item item)
    {
        var tempList = new List<InventoryElement>();

        for (int i = 0; i < _inventoryElements.Count; i++)
        {
            if (_inventoryElements[i].item == item)
            {
                tempList.Add(_inventoryElements[i]);
            }
        }

        return tempList;
    }

    private List<InventoryElement> FindOpenElements(Item item)
    {
        var tempList = new List<InventoryElement>();

        for (int i = 0; i < _inventoryElements.Count; i++)
        {
            if (_inventoryElements[i].item == item && _inventoryElements[i].count < _inventoryElements[i].item.MaxStackCount)
            {
                tempList.Add(_inventoryElements[i]);
            }
        }

        return tempList;
    }

    #region - Element Dragging -
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

        //This should only happen if the player drags the item off the inventory UI
        if (newNode == null)
        {
            Debug.Log("Removing from inventory");
            RemoveElement(element);
            return;
        }
        else if (display.OnValidateNewPosition(newNode, element.item.Width, element.item.Height))
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
    #endregion

    private void OnItemUsed(InventoryElement element)
    {
        element.item.UseItem();

        //Decrease one from the stack
        if (element.item is Consumable)
        {
            RemoveItem(element);
        }
        else if (element.item is Equipment)
        {
            //Likely have a separate script for managing equipment
            //Need to instantiate, remove previous weapon
            //I imagine an equipped item is removed from the inventory, so that needs to happen
        }
    }
}