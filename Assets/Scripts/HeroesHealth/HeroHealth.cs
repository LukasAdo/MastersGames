using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public string heroName;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public Vector2 gridPosition; // Position on the grid

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0)
        {
            Debug.LogWarning("Damage amount cannot be negative.");
            return;
        }

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        Debug.Log(heroName + " has died.");
        // Additional logic for when the hero dies
    }

    public void Attack(EnemyHealth enemy)
    {
        if (enemy == null)
        {
            Debug.LogWarning("Cannot attack a null enemy.");
            return;
        }

        enemy.TakeDamage(damage);
        Debug.Log(heroName + " attacked " + enemy.enemyName + " for " + damage + " damage.");
    }

    public bool CheckAdjacentTilesForAnimalDifference()
    {
        Vector2[] adjacentPositions = {
        gridPosition + Vector2.left,
        gridPosition + Vector2.right,
        gridPosition + Vector2.up,
        gridPosition + Vector2.down
    };

        Tile tile1 = GetTileAtPosition(adjacentPositions[0]);
        Tile tile2 = GetTileAtPosition(adjacentPositions[1]);

        if (tile1 != null)
        {
            Debug.Log($"Tile1 Tag: {tile1.tag}");
        }
        else
        {
            Debug.LogWarning("Tile1 is null.");
        }

        if (tile2 != null)
        {
            Debug.Log($"Tile2 Tag: {tile2.tag}");
        }
        else
        {
            Debug.LogWarning("Tile2 is null.");
        }

        if (tile1 != null && tile2 != null)
        {
            bool isDifferent = (tile1.CompareTag("Chicken") && !tile2.CompareTag("Chicken")) ||
                               (tile1.CompareTag("Cow") && !tile2.CompareTag("Cow")) ||
                               (tile1.CompareTag("Pig") && !tile2.CompareTag("Pig")) ||
                               (tile2.CompareTag("Chicken") && !tile1.CompareTag("Chicken")) ||
                               (tile2.CompareTag("Cow") && !tile1.CompareTag("Cow")) ||
                               (tile2.CompareTag("Pig") && !tile1.CompareTag("Pig"));

            Debug.Log($"Tiles have different animals: {isDifferent}");
            return isDifferent;
        }

        return false;
    }


    public Tile GetTileAtPosition(Vector2 position)
    {
        Tile tile = GridManager.instance.GetTileAtPosition(position);
        if (tile == null)
        {
            Debug.LogWarning($"No tile found at position {position}");
        }
        return tile;
    }
}
