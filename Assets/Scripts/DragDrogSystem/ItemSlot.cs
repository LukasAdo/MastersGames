using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            RectTransform droppedItem = eventData.pointerDrag.GetComponent<RectTransform>();
            droppedItem.SetParent(transform); // Set the parent to the drop zone
            droppedItem.anchoredPosition = Vector2.zero; // Center the dropped item
        }
    }
}