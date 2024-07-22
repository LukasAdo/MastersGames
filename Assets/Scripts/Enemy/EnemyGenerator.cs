using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public EnemyScriptableObject enemyConfig; // Reference to the Enemy Scriptable Object
    public GridManager gridManager; // Reference to the GridManager

    // Method to generate enemies at random walkable positions
    public void GenerateEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null && tile.OccupiedUnit == null)
            {
                Instantiate(enemyConfig.enemyPrefab, tile.transform.position, Quaternion.identity);
                Debug.Log($"Enemy spawned at {tile.transform.position}");
            }
            else
            {
                Debug.LogWarning("No walkable or unoccupied tile found for enemy generation.");
            }
        }
    }
}
