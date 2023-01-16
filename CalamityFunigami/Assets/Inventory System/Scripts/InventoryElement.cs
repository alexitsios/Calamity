using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryElement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public delegate void OnElementDragCallback(InventoryElement element);
    public OnElementDragCallback onElementBeginDrag;
    public OnElementDragCallback onElementEndDrag;

    [SerializeField] private RectTransform m_rect;
    public RectTransform Rect => m_rect;

    public Item item;
    public int count;

    public int gridX;
    public int gridY;
    public float zRotation;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Only begin drag with LMB
        if (eventData.button != PointerEventData.InputButton.Left) return;

        SetDraggedPosition(eventData);
        onElementBeginDrag?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Only register drag with LMB
        if (eventData.button != PointerEventData.InputButton.Left) return;
        SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Only register end drag with LMB
        if (eventData.button != PointerEventData.InputButton.Left) return;
        onElementEndDrag?.Invoke(this);
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        Vector3 globalMousePosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(data.pointerEnter.transform as RectTransform, data.position, data.pressEventCamera, out globalMousePosition))
        {
            m_rect.position = globalMousePosition;
        }
    }

    public void SetProperties(Item item, int x, int y, int count = 1)
    {
        this.item = item;
        gridX = x;
        gridY = y;

        this.count = count;
    }
}
