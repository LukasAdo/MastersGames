using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public CoinScriptableObject coinConfig; // Scriptable Object for coin configuration
    public GridManager gridManager;         // Reference to the GridManager

    public void GenerateCoins(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null)
            {
                Instantiate(coinConfig.coinPrefab, tile.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No walkable tile found for coin generation.");
            }
        }
    }
}
