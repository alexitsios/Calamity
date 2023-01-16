using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private InventoryGrid<GridNode> grid;

    [SerializeField] private int m_width;
    [SerializeField] private int m_height;
    [SerializeField] private float m_cellSize;
    [SerializeField] private Transform m_origin;

    public int Width => m_width;
    public int Height => m_height;
    public float CellSize => m_cellSize;
    public Transform Origin => m_origin;

    private List<GridNode> openList; //nodes to search

    [Header("Testing")]
    [SerializeField] private GameObject debugMarker;
    [SerializeField] private bool showDebug;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        grid = new InventoryGrid<GridNode>(this, m_width, m_height, m_cellSize, m_origin, (InventoryGrid<GridNode> grid, int x, int y) => new GridNode(grid, x, y), debugMarker, showDebug);
    }

    public void OnToggleNodeIsOccupied(int x, int y, bool isOccupied)
    {
        grid.GetGridObject(x, y).SetOccupied(isOccupied);
    }

    public GridNode GetNode(int x, int y)
    {
        return grid.GetGridObject(x, y);
    }

    /*public GridNode GetNode(Vector3 localPosition)
    {

    }*/

    public GridNode FindOpenNode(int width, int height, bool canRotate)
    {
        openList = new List<GridNode>();

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                GridNode node = grid.GetGridObject(x, y);
                if (!node.isOccupied)
                {
                    openList.Add(node);
                }
            }
        }

        if (openList.Count == 0)
        {
            Debug.Log("Zero open nodes in inventory");
        }

        foreach(GridNode node in openList)
        {
            //Now I need to check if all of the nodes above it in height are open
            //and all of the nodes to the right of it in width are open
            int startX = node.x;
            int startY = node.y;
            bool isClear = true;
            for (int x = startX; x < startX + width; x++)
            {
                if (x >= grid.GetWidth())
                {
                    //Debug.Log(x + "," + startY + " is out of bounds");
                    isClear = false;
                    break;
                }
                if (GetNode(x, startY).isOccupied)
                {
                    //Debug.Log(x + "," + startY + " is not clear");
                    isClear = false;
                    break;
                }
                //Debug.Log(x + "," + startY + " is clear");
            }
            for (int y = startY; y < startY + height; y++)
            {
                if (y >= grid.GetHeight())
                {
                    //Debug.Log(startX + "," + y + " is out of bounds");
                    isClear = false;
                    break;
                }
                if (GetNode(startX, y).isOccupied)
                {
                    //Debug.Log(startX + "," + y + " is not clear");
                    isClear = false;
                    break;
                }
                //Debug.Log(startX + "," + y + " is clear");
            }

            if (isClear)
            {
                //Debug.Log("Open Node Found at " + startX + "," + startY);
                return node;
            }
        }

        return null;
    }

    public void ToggleNodesOccupied(GridNode startNode, int width, int height, bool isOccupied)
    {
        startNode.SetOccupied(isOccupied);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GetNode(startNode.x + x, startNode.y + y).SetOccupied(isOccupied);
                //Debug.Log("node " + (startNode.x + x) + "," + (startNode.y + y) + " is occupied: " + isOccupied);
            }
        }
    }

    public Vector3 GetGridPosition(int x, int y)
    {
        return m_origin.position + new Vector3(x * CellSize, y * CellSize);
    }

    public bool OnValidateNewPosition(GridNode newNode, int width, int height)
    {
        int startX = newNode.x;
        int startY = newNode.y;

        for (int x = startX; x < startX + width; x++)
        {
            if (x >= grid.GetWidth())
            {
                //Debug.Log(x + "," + startY + " is out of bounds");
                return false;
            }
            if (GetNode(x, startY).isOccupied)
            {
                //Debug.Log(x + "," + startY + " is not clear");
                return false;
            }
            //Debug.Log(x + "," + startY + " is clear");
        }
        for (int y = startY; y < startY + height; y++)
        {
            if (y >= grid.GetHeight())
            {
                //Debug.Log(startX + "," + y + " is out of bounds");
                return false;
            }
            if (GetNode(startX, y).isOccupied)
            {
                //Debug.Log(startX + "," + y + " is not clear");
                return false;
            }
            //Debug.Log(startX + "," + y + " is clear");
        }

        return true;
    }
}
