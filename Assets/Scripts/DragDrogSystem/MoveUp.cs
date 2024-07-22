using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MoveBlock
{
    public override void MoveUnit()
    {
        BaseUnit selectedUnit = FindObjectOfType<BaseUnit>(); // Simplified, replace with your actual selection logic

        if (selectedUnit != null && selectedUnit.OccupiedTile != null)
        {
            selectedUnit.OccupiedTile.MoveUnitUp();
        }
        else
        {
            Debug.Log("No selected unit or selected unit is not on a tile.");
        }
    }
}

// Movement methods can remain as they are for direct movement

// A* Pathfinding methods

