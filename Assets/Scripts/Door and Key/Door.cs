using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public DoorScriptableObject doorConfig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.HasKey(doorConfig.requiredKeyID))
            {
                UnlockDoor();
            }
            else
            {
                Debug.Log("Door locked. Key required: " + doorConfig.requiredKeyID);
            }
        }
    }

    private void UnlockDoor()
    {
        Debug.Log("Door unlocked: " + doorConfig.requiredKeyID);
        Destroy(gameObject); // Or play an animation to open the door
    }
}
