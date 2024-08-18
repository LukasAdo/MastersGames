using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneSpeech : MonoBehaviour
{
    public GameObject[] speechTexts; // Array to hold references to the text GameObjects
    public Button nextButton; // Reference to the next button
    public GameObject speechBubble; // Reference to the speech bubble GameObject
    public GameObject heroIcon; // Reference to the hero icon GameObject

    private int currentTextIndex = 0;

    private void Start()
    {
        // Ensure all speech texts are initially inactive
        foreach (GameObject speechText in speechTexts)
        {
            speechText.SetActive(false);
        }

        // Show the first text
        ShowNextMessage();

        // Add a listener to the next button
        nextButton.onClick.AddListener(ShowNextMessage);
    }

    public void ShowNextMessage()
    {
        // Deactivate the previous text
        if (currentTextIndex > 0 && currentTextIndex <= speechTexts.Length)
        {
            speechTexts[currentTextIndex - 1].SetActive(false);
        }

        // Check if we are within the bounds of the array
        if (currentTextIndex < speechTexts.Length)
        {
            // Activate the current text
            speechTexts[currentTextIndex].SetActive(true);
            currentTextIndex++;
        }
        else
        {
            // All texts have been shown, end the tutorial
            EndTutorial();
        }
    }

    private void EndTutorial()
    {
        // Optionally, perform any actions needed at the end of the tutorial
        nextButton.gameObject.SetActive(false); // Hide the next button
        Debug.Log("Tutorial Ended");

        // Destroy the speech bubble and hero icon
        if (speechBubble != null)
        {
            Destroy(speechBubble);
        }

        if (heroIcon != null)
        {
            Destroy(heroIcon);
        }
    }
}
