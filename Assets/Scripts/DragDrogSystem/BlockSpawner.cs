using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject upBlockPrefab;
    public GameObject downBlockPrefab;
    public GameObject leftBlockPrefab;
    public GameObject rightBlockPrefab;

    private GameObject[] upEmptyBlocks;
    private GameObject[] downEmptyBlocks;
    private GameObject[] leftEmptyBlocks;
    private GameObject[] rightEmptyBlocks;

    void Start()
    {
        // Find all empty game objects with their respective tags
        upEmptyBlocks = GameObject.FindGameObjectsWithTag("UpEmptyBlock");
        downEmptyBlocks = GameObject.FindGameObjectsWithTag("DownEmptyBlock");
        leftEmptyBlocks = GameObject.FindGameObjectsWithTag("LeftEmptyBlock");
        rightEmptyBlocks = GameObject.FindGameObjectsWithTag("RightEmptyBlock");

        // Check if any empty game objects were found
        if (upEmptyBlocks.Length == 0 && downEmptyBlocks.Length == 0 &&
            leftEmptyBlocks.Length == 0 && rightEmptyBlocks.Length == 0)
        {
            Debug.LogError("No empty block game objects found!");
        }
    }

    public void OnBlockPlaced(GameObject placedBlock)
    {
        Debug.Log($"OnBlockPlaced called with: {placedBlock.name}");

        GameObject[] emptyBlockObjects;
        switch (placedBlock.tag)
        {
            case "UpBlock":
                emptyBlockObjects = upEmptyBlocks;
                break;
            case "DownBlock":
                emptyBlockObjects = downEmptyBlocks;
                break;
            case "LeftBlock":
                emptyBlockObjects = leftEmptyBlocks;
                break;
            case "RightBlock":
                emptyBlockObjects = rightEmptyBlocks;
                break;
            default:
                Debug.LogError("Unknown block type: " + placedBlock.tag);
                return;
        }

        if (emptyBlockObjects != null && placedBlock != null)
        {
            GameObject emptyBlockObject = FindInactiveObject(emptyBlockObjects);
            if (emptyBlockObject != null)
            {
                GameObject prefab = GetBlockPrefab(placedBlock.tag);
                if (prefab != null)
                {
                    Debug.Log($"Spawning {prefab.name} at {emptyBlockObject.name}");
                    Instantiate(prefab, emptyBlockObject.transform.position, Quaternion.identity);
                    emptyBlockObject.SetActive(true);
                }
                else
                {
                    Debug.LogError("Prefab not assigned for tag: " + placedBlock.tag);
                }
            }
            else
            {
                Debug.LogWarning("No inactive empty block found for " + placedBlock.tag);
            }
        }
        else
        {
            Debug.LogError("Invalid empty block objects or placed block.");
        }
    }

    private GameObject GetBlockPrefab(string blockTag)
    {
        switch (blockTag)
        {
            case "UpBlock":
                return upBlockPrefab;
            case "DownBlock":
                return downBlockPrefab;
            case "LeftBlock":
                return leftBlockPrefab;
            case "RightBlock":
                return rightBlockPrefab;
            default:
                return null;
        }
    }

    private GameObject FindInactiveObject(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
}
