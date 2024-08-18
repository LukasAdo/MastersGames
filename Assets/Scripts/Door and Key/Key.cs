using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyID;  // Unique identifier for the key

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectKey();
        }
    }

    private void CollectKey()
    {
        Debug.Log("Key collected: " + keyID);
        GameManager.Instance.CollectKey(keyID);
        Destroy(gameObject);
    }
}
