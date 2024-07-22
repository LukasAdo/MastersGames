using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool isWalkable;

    public BaseUnit OccupiedUnit;
    public bool IsWalkable => isWalkable && OccupiedUnit == null;

    public int gridX; // X position in the grid
    public int gridY; // Y position in the grid
  

    public int gCost; // Cost from the starting tile to this tile
    public int hCost; // Heuristic cost from this tile to the target tile
    public int FCost { get { return gCost + hCost; } } // Total cost (gCost + hCost)

    public List<Tile> GetNeighbours()
    {
        List<Tile> neighbours = new List<Tile>();
        // Implement logic to find neighbouring tiles (left, right, up, down)
        return neighbours;
    }

    public virtual void Init(int x, int y)
    {
       
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }

    public void MoveUnitLeft()
    {
        GridManager gridManager = GridManager.instance;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPos = currentPos + Vector2.left;

        Tile leftTile = gridManager.GetTileAtPosition(newPos);

        if (leftTile != null && leftTile.IsWalkable)
        {
            leftTile.SetUnit(OccupiedUnit);
            OccupiedUnit = null;
        }
    }
    public void MoveUnitRight()
    {
        GridManager gridManager = GridManager.instance;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPos = currentPos + Vector2.right;

        Tile rightTile = gridManager.GetTileAtPosition(newPos);

        if (rightTile != null && rightTile.IsWalkable)
        {
            rightTile.SetUnit(OccupiedUnit);
            OccupiedUnit = null;
        }
    }
    public void MoveUnitUp()
    {
        GridManager gridManager = GridManager.instance;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPos = currentPos + Vector2.up;

        Tile upTile = gridManager.GetTileAtPosition(newPos);

        if (upTile != null && upTile.IsWalkable)
        {
            upTile.SetUnit(OccupiedUnit);
            OccupiedUnit = null;
        }
    }
    public void MoveUnitDown()
    {
        GridManager gridManager = GridManager.instance;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPos = currentPos + Vector2.down;

        Tile downTile = gridManager.GetTileAtPosition(newPos);

        if (downTile != null && downTile.IsWalkable)
        {
            downTile.SetUnit(OccupiedUnit);
            OccupiedUnit = null;
        }
    }
    
}


