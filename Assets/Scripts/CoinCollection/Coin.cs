using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinScriptableObject coinConfig; // Assign in Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered!");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Coin collected by player!");
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        GameManager.Instance.AddScore(coinConfig.coinValue); // Add score based on coin value
        Debug.Log($"Added {coinConfig.coinValue} to score.");
        Destroy(gameObject); // Destroy the coin object
    }
}
