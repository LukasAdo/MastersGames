using UnityEngine;

public class DoorKeyGenerator : MonoBehaviour
{
    public KeyScriptableObject keyConfig; // Reference to the Key Scriptable Object
    public DoorScriptableObject doorConfig; // Reference to the Door Scriptable Object
    public BrokenKeyScriptableObject brokenKeyConfig;
    public GridManager gridManager; // Reference to the GridManager

    // Method to generate keys at random walkable positions
    public void GenerateKeys(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null)
            {
                Instantiate(keyConfig.keyPrefab, tile.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No walkable tile found for key generation.");
            }
        }
    }

    // Method to generate doors at random walkable positions
    public void GenerateDoors(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null)
            {
                Instantiate(doorConfig.doorPrefab, tile.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No walkable tile found for door generation.");
            }
        }
    }
    public void GenerateBrokenKeys(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null)
            {
                Instantiate(brokenKeyConfig.brokenKeyPrefab, tile.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No walkable tile found for broken key generation.");
            }
        }
    }
}

