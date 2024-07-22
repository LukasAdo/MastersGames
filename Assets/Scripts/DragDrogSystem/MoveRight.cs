using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MoveBlock
{
    public override void MoveUnit()
    {
        BaseUnit selectedUnit = FindObjectOfType<BaseUnit>(); // Simplified, replace with your actual selection logic

        if (selectedUnit != null && selectedUnit.OccupiedTile != null)
        {
            selectedUnit.OccupiedTile.MoveUnitRight();
        }
        else
        {
            Debug.Log("No selected unit or selected unit is not on a tile.");
        }
    }
}
