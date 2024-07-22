using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class MoveBlock : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public List<GameObject> dropZones; // List of drop zone GameObjects
    public Button moveButton; // Reference to the UI Button for character movement
    protected bool isInDropZone = false; // Track if the block is in any drop zone

    [SerializeField] private BaseUnit selectedUnit; // Reference to the selected unit (hero)

    void Start()
    {
        if (moveButton == null)
        {
            Debug.LogWarning("Move button not assigned or found.");
        }
        else
        {
            moveButton.interactable = false; // Initially disable the button
        }

        if (dropZones == null || dropZones.Count == 0)
        {
            Debug.LogError("Drop zones not assigned.");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Debug.Log($"Dragging... Position: {transform.position}");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject hitObject = eventData.pointerCurrentRaycast.gameObject;
        bool droppedInZone = false;

        foreach (GameObject dropZone in dropZones)
        {
            if (hitObject == dropZone)
            {
                isInDropZone = true;
                moveButton.interactable = true;
                droppedInZone = true;
                Debug.Log("Dropped in a drop zone.");
                break;
            }
        }

        if (!droppedInZone)
        {
            isInDropZone = false;
            moveButton.interactable = false;
            Debug.Log("Dropped outside any drop zone.");
        }
    }

    public bool IsInDropZone()
    {
        return isInDropZone;
    }

    public abstract void MoveUnit(); // Abstract method to be implemented by subclasses
}
