using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenKey : MonoBehaviour
{
    public BrokenKeyScriptableObject brokenKeyConfig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectBrokenKey();
        }
    }

    private void CollectBrokenKey()
    {
        Debug.Log("Broken key collected: " + brokenKeyConfig.brokenKeyID);
        GameManager.Instance.CollectBrokenKey(brokenKeyConfig.brokenKeyID);
        Destroy(gameObject);
    }
}
