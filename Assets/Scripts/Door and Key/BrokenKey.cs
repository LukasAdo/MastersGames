using UnityEngine;

public class BrokenKey : MonoBehaviour
{
    public string brokenKeyID;  // Unique identifier for the broken key

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectBrokenKey();
        }
    }

    private void CollectBrokenKey()
    {
        Debug.Log("Broken key collected: " + brokenKeyID);
        GameManager.Instance.CollectBrokenKey(brokenKeyID);
        Destroy(gameObject);
    }
}
