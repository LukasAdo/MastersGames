using UnityEngine;
using TMPro; // Ensure this is included if you use TextMeshPro

public class TooltipController : MonoBehaviour
{
    public GameObject tooltip;             // Reference to the tooltip UI GameObject
    public TextMeshProUGUI tooltipText;    // Reference to the first text field
    public TextMeshProUGUI tooltipText2;   // Reference to the second text field

    private void Start()
    {
        // Ensure the tooltip is hidden initially
        tooltip.SetActive(false);
    }

    public void ShowTooltip()
    {
        tooltip.SetActive(true); // Show the tooltip
    }

    public void HideTooltip()
    {
        tooltip.SetActive(false); // Hide the tooltip
    }
}
