using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public List<MoveBlock> moveBlocks; // List of scripts handling block movements and drop zones

    public void OnMoveButtonClick()
    {
        Debug.Log("Move button clicked.");

        // Check if it's the player's turn
        if (GameManager.Instance.GameState == GameState.HeroesTurn)
        {
            // Iterate through each move block
            foreach (var moveBlock in moveBlocks)
            {
                if (moveBlock != null && moveBlock.IsInDropZone())
                {
                    Debug.Log($"{moveBlock.name} block is in the drop zone. Moving unit.");
                    moveBlock.MoveUnit();
                }
                else
                {
                    Debug.Log($"{moveBlock.name} block is not in the drop zone. Cannot move unit.");
                }
            }

            // End the player's turn
            GameManager.Instance.EndPlayerTurn();
        }
        else
        {
            Debug.Log("It's not the player's turn.");
            // Handle UI feedback or logic for when it's not the player's turn
        }
    }
}
