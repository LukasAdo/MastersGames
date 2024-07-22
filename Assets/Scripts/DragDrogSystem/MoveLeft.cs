using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class MoveLeft : MoveBlock
{
    public override void MoveUnit()
    {
        BaseUnit selectedUnit = FindObjectOfType<BaseUnit>(); // Simplified, replace with your actual selection logic

        if (selectedUnit != null && selectedUnit.OccupiedTile != null)
        {
            selectedUnit.OccupiedTile.MoveUnitLeft();
        }
        else
        {
            Debug.Log("No selected unit or selected unit is not on a tile.");
        }
    }
}