using UnityEngine;

public class DoorKeyGenerator : MonoBehaviour
{
    public GameObject keyPrefab;         // GameObject for the key prefab
    public GameObject doorPrefab;        // GameObject for the door prefab
    public GameObject brokenKeyPrefab;   // GameObject for the broken key prefab
    public GridManager gridManager;      // Reference to the GridManager

    // Method to generate keys at random walkable positions
    public void GenerateKeys(int count)
    {
        if (keyPrefab == null)
        {
            Debug.LogError("Key prefab is not assigned.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null)
            {
                Instantiate(keyPrefab, tile.transform.position, Quaternion.identity);
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
        if (doorPrefab == null)
        {
            Debug.LogError("Door prefab is not assigned.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null)
            {
                Instantiate(doorPrefab, tile.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No walkable tile found for door generation.");
            }
        }
    }

    // Method to generate broken keys at random walkable positions
    public void GenerateBrokenKeys(int count)
    {
        if (brokenKeyPrefab == null)
        {
            Debug.LogError("Broken key prefab is not assigned.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Tile tile = gridManager.GetRandomWalkableTile();
            if (tile != null)
            {
                Instantiate(brokenKeyPrefab, tile.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No walkable tile found for broken key generation.");
            }
        }
    }
}

