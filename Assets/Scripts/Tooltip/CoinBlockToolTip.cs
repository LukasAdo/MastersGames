using UnityEngine;
using UnityEngine.EventSystems;

public class CoinBlockToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TooltipController tooltipController; // Reference to the TooltipController

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show the tooltip when hovering over the coin block
        tooltipController.ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the tooltip when not hovering
        tooltipController.HideTooltip();
    }
}
