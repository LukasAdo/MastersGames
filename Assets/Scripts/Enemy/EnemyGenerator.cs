using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;  // GameObject for the enemy prefab
    public GridManager gridManager; // Reference to the GridManager

    // Method to generate enemies at random walkable positions
    public void GenerateEnemies(int count)
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is not assigned.");
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
            if (tile != null && tile.OccupiedUnit == null)
            {
                Instantiate(enemyPrefab, tile.transform.position, Quaternion.identity);
                Debug.Log($"Enemy spawned at {tile.transform.position}");
            }
            else
            {
                Debug.LogWarning("No walkable or unoccupied tile found for enemy generation.");
            }
        }
    }
}
