using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredKeyID;  // Unique identifier for the required key

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.HasKey(requiredKeyID))
            {
                UnlockDoor();
            }
            else
            {
                Debug.Log("Door locked. Key required: " + requiredKeyID);
            }
        }
    }

    private void UnlockDoor()
    {
        Debug.Log("Door unlocked: " + requiredKeyID);
        Destroy(gameObject); // Or play an animation to open the door
    }
}
