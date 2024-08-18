using System.Collections.Generic;
using UnityEngine;

public class EqualityBlock : MoveBlock
{
    public Hero hero; // Reference to the hero
    public GridManager gridManager; // Reference to the GridManager
    public List<GameObject> allAnimals; // List of all animals in the game

    private void Start()
    {
        if (hero == null)
        {
            Debug.LogError("Hero reference is not assigned.");
        }

        if (gridManager == null)
        {
            Debug.LogError("GridManager reference is not assigned.");
        }

        if (allAnimals == null)
        {
            Debug.LogError("AllAnimals list is not assigned.");
        }
    }

    public override void MoveUnit()
    {
        if (hero == null || gridManager == null || allAnimals == null)
        {
            Debug.LogError("Required references are not assigned.");
            return;
        }

        CheckAndDestroySameTagAnimals();
    }

    private void CheckAndDestroySameTagAnimals()
    {
        Vector2 heroPosition = new Vector2(Mathf.Round(hero.transform.position.x), Mathf.Round(hero.transform.position.y));

        // Define adjacent positions
        Vector2[] adjacentPositions = {
            heroPosition + Vector2.left,
            heroPosition + Vector2.right,
            heroPosition + Vector2.up,
            heroPosition + Vector2.down
        };

        List<GameObject> animalsToCheck = new List<GameObject>();

        foreach (Vector2 pos in adjacentPositions)
        {
            if (gridManager.IsWithinBounds(pos))
            {
                // Check for animals at the adjacent tile positions
                foreach (GameObject animal in allAnimals)
                {
                    Vector2 animalPosition = new Vector2(Mathf.Round(animal.transform.position.x), Mathf.Round(animal.transform.position.y));
                    if (animalPosition == pos)
                    {
                        animalsToCheck.Add(animal);
                        Debug.Log($"Detected animal with tag {animal.tag} at position {pos}");
                    }
                }
            }
        }

        // Check for pairs of animals with the same tag
        DestroyPairIfFound(animalsToCheck, "Chicken");
        DestroyPairIfFound(animalsToCheck, "Cow");
        DestroyPairIfFound(animalsToCheck, "Pig");
    }

    private void DestroyPairIfFound(List<GameObject> animals, string animalTag)
    {
        List<GameObject> foundAnimals = animals.FindAll(a => a.CompareTag(animalTag));

        if (foundAnimals.Count >= 2)
        {
            Debug.Log($"Found two {animalTag}s. Destroying them.");
            Destroy(foundAnimals[0]);
            Destroy(foundAnimals[1]);
        }
        else
        {
            Debug.Log($"Not enough {animalTag}s found.");
        }
    }
}
