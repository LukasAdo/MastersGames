using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIfElse : MoveBlock
{
    public Hero hero; // Reference to the hero character
    public float attackRange = 1.0f; // Range within which an enemy can be attacked
    public float attackDamage = 10.0f; // Amount of damage dealt per attack

    // Override the abstract method from MoveBlock
    public override void MoveUnit()
    {
        if (hero == null)
        {
            Debug.LogError("Hero reference is not assigned.");
            return;
        }

        // Check if there are any enemies with the "Enemy" tag within range
        EnemyHealth targetEnemy = FindTargetEnemy();
        if (targetEnemy != null)
        {
            DealDamage(targetEnemy);
            Debug.Log("Attacked enemy: " + targetEnemy.enemyName);
        }
        else
        {
            Debug.Log("No enemy within attack range.");
            ExecuteElseBlock();
        }
    }

    private EnemyHealth FindTargetEnemy()
    {
        foreach (var enemy in FindObjectsOfType<EnemyHealth>())
        {
            if (enemy.CompareTag("Enemy") && IsWithinRange(hero.transform.position, enemy.transform.position))
            {
                Debug.Log("Target enemy found: " + enemy.enemyName);
                return enemy;
            }
        }
        Debug.Log("No target enemy found.");
        return null;
    }

    private bool IsWithinRange(Vector2 heroPosition, Vector2 enemyPosition)
    {
        return Vector2.Distance(heroPosition, enemyPosition) <= attackRange;
    }

    private void DealDamage(EnemyHealth enemy)
    {
        // Perform any additional logic before dealing damage
        Debug.Log("Dealing damage to enemy: " + enemy.enemyName);
        enemy.TakeDamage(attackDamage); // Reduce the enemy's health
    }

    private void ExecuteElseBlock()
    {
        if (IsInDropZone())
        {
            Debug.Log("Executing else block actions.");
            // Example: Update UI, activate functionality, etc.
        }
        else
        {
            Debug.Log("Not in a valid drop zone.");
        }
    }

    private bool IsInDropZone()
    {
        // Stub implementation; replace with actual logic
        return true; // Change this to your actual condition
    }
}
