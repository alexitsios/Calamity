using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class InventoryGrid<TGridObject>
{
    //This event is called whenever a grid value changes
    public event EventHandler<OnGridValueChangedEventArgs> onGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    private int width; //The number of columns
    private int height; //The number of rows
    private float cellSize; //The size of each grid element
    private Vector3 originPosition; //The bottom left corner of the grid, tile [0,0]
    private TGridObject[,] gridArray;

    private GameObject debugMarker;

    public InventoryGrid(InventoryDisplay display, int width, int height, float cellSize, Transform origin, Func<InventoryGrid<TGridObject>, int, int, TGridObject> createdGridObject, GameObject marker = null, bool showDebug = false)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = origin.position;

        this.debugMarker = marker;

        gridArray = new TGridObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createdGridObject(this, x, y);
            }
        }

        if (showDebug)
        {
            TMP_Text[,] debugTextArray = new TMP_Text[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = GameObject.Instantiate(debugMarker, GetGridPosition(x, y), Quaternion.identity);
                    go.transform.SetParent(origin);
                    go.transform.SetParent(display.Origin);

                    debugTextArray[x, y] = go.GetComponentInChildren<TMP_Text>();
                    debugTextArray[x, y].text = gridArray[x, y]?.ToString();
                }
            }

            onGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
            {
                debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y]?.ToString();
                var node = display.GetNode(eventArgs.x, eventArgs.y);
                if (node.isOccupied) debugTextArray[eventArgs.x, eventArgs.y].color = Color.red;
                else debugTextArray[eventArgs.x, eventArgs.y].color = Color.black;
            };
        }
    }

    private Vector3 GetGridPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            TriggerGridObjectChanged(x, y);
        }
    }

    //method to update the grid upon value change
    public void TriggerGridObjectChanged(int x, int y)
    {
        if (onGridValueChanged != null) onGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }

        //Invalid, outside of array
        return default(TGridObject);
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }
}
