using System.Collections.Generic;
using UnityEngine;

public class AnimalGenerator : MonoBehaviour
{
    // Prefabs for animals
    public GameObject chickenPrefab;
    public GameObject cowPrefab;
    public GameObject pigPrefab;
    public GridManager gridManager;

    // Number of additional animals to spawn randomly
    public int additionalChickens = 2;
    public int additionalCows = 2;
    public int additionalPigs = 2;

    public void GenerateAnimals()
    {
        if (gridManager == null)
        {
            Debug.LogError("GridManager is not assigned.");
            return;
        }

        if (chickenPrefab == null || cowPrefab == null || pigPrefab == null)
        {
            Debug.LogError("One or more animal prefabs are not assigned.");
            return;
        }

        List<Tile> walkableTiles = gridManager.GetAllWalkableTiles();

        if (walkableTiles == null || walkableTiles.Count < 9)
        {
            Debug.LogWarning("Not enough walkable tiles to spawn all animals.");
            return;
        }

        // Existing gap-based animal spawning
        List<Tile> chickenTiles = SelectTilesWithGaps(walkableTiles);
        List<Tile> cowTiles = SelectTilesWithGaps(walkableTiles);
        List<Tile> pigTiles = SelectTilesWithGaps(walkableTiles);

        if (chickenTiles.Count < 3 || cowTiles.Count < 3 || pigTiles.Count < 3)
        {
            Debug.LogWarning("Not enough suitable tiles found to spawn all animals.");
            return;
        }

        // Spawn two of each animal with a gap
        SpawnAnimalWithGap(chickenPrefab, chickenTiles[0], chickenTiles[2]);
        SpawnAnimalWithGap(cowPrefab, cowTiles[0], cowTiles[2]);
        SpawnAnimalWithGap(pigPrefab, pigTiles[0], pigTiles[2]);

        // Spawn additional random animals
        SpawnAdditionalAnimals(chickenPrefab, additionalChickens, walkableTiles);
        SpawnAdditionalAnimals(cowPrefab, additionalCows, walkableTiles);
        SpawnAdditionalAnimals(pigPrefab, additionalPigs, walkableTiles);
    }

    private void SpawnAnimalWithGap(GameObject prefab, Tile tile1, Tile tile2)
    {
        Instantiate(prefab, tile1.transform.position, Quaternion.identity);
        Instantiate(prefab, tile2.transform.position, Quaternion.identity);
    }

    private List<Tile> SelectTilesWithGaps(List<Tile> walkableTiles)
    {
        List<Tile> selectedTiles = new List<Tile>();

        while (selectedTiles.Count < 3) // Need three tiles: animal, gap, animal
        {
            int randomIndex = Random.Range(0, walkableTiles.Count);
            Tile tile1 = walkableTiles[randomIndex];

            // Ensure the adjacent tile has a gap of at least one tile
            Tile tile2 = walkableTiles.Find(tile =>
                !selectedTiles.Contains(tile) &&
                (Mathf.Abs(tile.transform.position.x - tile1.transform.position.x) == 2 && tile.transform.position.y == tile1.transform.position.y) ||
                (Mathf.Abs(tile.transform.position.y - tile1.transform.position.y) == 2 && tile.transform.position.x == tile1.transform.position.x)
            );

            if (tile2 != null)
            {
                selectedTiles.Add(tile1);
                selectedTiles.Add(walkableTiles.Find(tile =>
                    !selectedTiles.Contains(tile) &&
                    ((tile.transform.position.x - tile1.transform.position.x == 1 && tile.transform.position.y == tile1.transform.position.y) ||
                    (tile.transform.position.y - tile1.transform.position.y == 1 && tile.transform.position.x == tile1.transform.position.x))
                ));
                selectedTiles.Add(tile2);

                // Remove the selected tiles from the list
                walkableTiles.Remove(tile1);
                walkableTiles.Remove(tile2);
            }

            if (walkableTiles.Count < 3)
            {
                Debug.LogWarning("Not enough remaining walkable tiles to complete selection.");
                break;
            }
        }

        return selectedTiles;
    }

    private void SpawnAdditionalAnimals(GameObject prefab, int count, List<Tile> walkableTiles)
    {
        for (int i = 0; i < count; i++)
        {
            if (walkableTiles.Count == 0)
            {
                Debug.LogWarning("Not enough walkable tiles to spawn additional animals.");
                break;
            }

            int randomIndex = Random.Range(0, walkableTiles.Count);
            Tile tile = walkableTiles[randomIndex];
            Instantiate(prefab, tile.transform.position, Quaternion.identity);
            walkableTiles.RemoveAt(randomIndex); // Ensure no duplicate tiles
        }
    }
}
