using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;  // GameObject for coin prefab
    public GridManager gridManager; // Reference to the GridManager

    public void GenerateCoins(int count)
    {
        if (coinPrefab == null)
        {
            Debug.LogError("Coin prefab is not assigned.");
            return;
        }

        if (gridManager == null)
        {
            Debug.LogError("GridManager is not assigned.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null)
            {
                Instantiate(coinPrefab, tile.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No walkable tile found for coin generation.");
            }
        }
    }
}
