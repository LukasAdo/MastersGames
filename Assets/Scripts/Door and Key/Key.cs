using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyScriptableObject keyConfig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectKey();
        }
    }

    private void CollectKey()
    {
        Debug.Log("Key collected: " + keyConfig.keyID);
        GameManager.Instance.CollectKey(keyConfig.keyID);
        Destroy(gameObject);
    }
}
