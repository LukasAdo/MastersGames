using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MoveBlock
{
    public override void MoveUnit()
    {
        BaseUnit selectedUnit = FindObjectOfType<BaseUnit>(); // Simplified, replace with your actual selection logic

        if (selectedUnit != null && selectedUnit.OccupiedTile != null)
        {
            selectedUnit.OccupiedTile.MoveUnitDown();
        }
        else
        {
            Debug.Log("No selected unit or selected unit is not on a tile.");
        }
    }
}
