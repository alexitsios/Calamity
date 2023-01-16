public class GridNode
{
    private InventoryGrid<GridNode> inventoryGrid;

    public int x { get; private set; }
    public int y { get; private set; }

    public bool isOccupied { get; private set; }

    public GridNode(InventoryGrid<GridNode> grid, int x, int y)
    {
        inventoryGrid = grid;
        this.x = x;
        this.y = y;

        isOccupied = false;
    }

    //Toggle whether the node is occupied by an item
    public void SetOccupied(bool isOccupied)
    {
        this.isOccupied = isOccupied;
        inventoryGrid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return x + "," + y;
    }
}
