using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{
    public Vector2 gridPosition; // Player's position on the grid
    public Tile currentTile; // The tile the player is currently on

    // Method to get a tile at a specific position
    public Tile GetTileAtPosition(Vector2 position)
    {
        // Assuming a method to get tile by position exists
        return GridManager.instance.GetTileAtPosition(position);
    }

    public bool CheckAdjacentTilesForDifference()
    {
        Vector2[] adjacentPositions = {
            gridPosition + Vector2.left,
            gridPosition + Vector2.right,
            gridPosition + Vector2.up,
            gridPosition + Vector2.down
        };

        Tile tile1 = GetTileAtPosition(adjacentPositions[0]);
        Tile tile2 = GetTileAtPosition(adjacentPositions[1]);

        if (tile1 != null && tile2 != null)
        {
            return tile1.tileType != tile2.tileType;
        }

        return false;
    }
}
