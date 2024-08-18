using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Coin value to be assigned in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        GameManager.Instance.AddScore(coinValue); // Add score based on coin value
        Debug.Log($"Added {coinValue} to score.");
        GameManager.Instance.CollectCoin(); // Notify GameManager of coin collection
        Destroy(gameObject); // Destroy the coin object
    }
}
