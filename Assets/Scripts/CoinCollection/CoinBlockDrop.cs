using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoinBlockDrop : MoveBlock
{
    // Update is called once per frame
    void Update()
    {
        // Handle updates specific to CoinBlockDrop if necessary
    }

    // Implement the abstract method from MoveBlock
    public override void MoveUnit()
    {
        Debug.Log("HandleCoinBlockFunctionality called."); // Debug line to verify execution

        if (IsInDropZone())
        {
            Debug.Log("Coin Block is in a drop zone.");
            CheckCoinsAndFinishLevel();
        }
    }

   


    private void CheckCoinsAndFinishLevel()
    {
        Debug.Log("CheckCoinsAndFinishLevel called."); // Debug line to verify execution
        int collectedCoins = GameManager.Instance.GetCollectedCoins();
        if (collectedCoins >= 5)
        {
            GameManager.Instance.FinishLevelOne();
        }
        else
        {
            Debug.Log("Not enough coins collected to finish the level.");
        }
    }



}