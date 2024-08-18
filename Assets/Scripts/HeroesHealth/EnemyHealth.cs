using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public string enemyName;
    public float maxHealth;
    private float currentHealth;
    public int damage;
    public Slider healthBar; // Reference to the UI slider for the health bar
    public Vector2 gridPosition; // Define gridPosition in EnemyHealth

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    // Method to handle taking damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthBar();
    }

    // Method to handle the enemy's death
    void Die()
    {
        // Handle enemy death (e.g., play animation, destroy object, etc.)
        Destroy(gameObject);
    }
}