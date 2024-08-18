using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour
{
    // Home screen buttons
    public Button playButton;
    public Button aboutButton;
    public Button optionsButton;
    public Button quitButton;

    // Levels screen buttons
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button returnFromLevelsButton; // Return button for Levels Screen

    // About screen buttons
    public Button returnFromAboutButton; // Return button for About Screen

    // Options screen buttons
    public Button returnFromOptionsButton; // Return button for Options Screen

    // Screens
    public GameObject homeScreen;
    public GameObject levelsScreen;
    public GameObject aboutScreen;
    public GameObject optionsScreen;

    void Start()
    {
        // Assign button listeners for home screen
        playButton.onClick.AddListener(OnPlayButtonClicked);
        aboutButton.onClick.AddListener(OnAboutButtonClicked);
        optionsButton.onClick.AddListener(OnOptionsButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);

        // Assign button listeners for levels screen
        level1Button.onClick.AddListener(() => LoadLevel(1)); // Assuming Level 1 is at index 1
        level2Button.onClick.AddListener(() => LoadLevel(2)); // Assuming Level 2 is at index 2
        level3Button.onClick.AddListener(() => LoadLevel(3)); // Assuming Level 3 is at index 3
        level4Button.onClick.AddListener(() => LoadLevel(4)); // Assuming Level 4 is at index 4
        returnFromLevelsButton.onClick.AddListener(OnReturnFromLevelsButtonClicked);

        // Assign button listeners for about screen
        returnFromAboutButton.onClick.AddListener(OnReturnFromAboutButtonClicked);

        // Assign button listeners for options screen
        returnFromOptionsButton.onClick.AddListener(OnReturnFromOptionsButtonClicked);

        // Initially set home screen active and others inactive
        homeScreen.SetActive(true);
        levelsScreen.SetActive(false);
        aboutScreen.SetActive(false);
        optionsScreen.SetActive(false);
    }

    private void OnPlayButtonClicked()
    {
        // Activate the levels screen
        SetActiveScreen(levelsScreen);
    }

    private void OnAboutButtonClicked()
    {
        // Activate the about screen
        SetActiveScreen(aboutScreen);
    }

    private void OnOptionsButtonClicked()
    {
        // Activate the options screen
        SetActiveScreen(optionsScreen);
    }

    private void OnQuitButtonClicked()
    {
        // Quit the application
        Application.Quit();
        // Note: This will not work in the Unity Editor. To test it, you'll need to build and run your application.
    }

    private void OnReturnFromLevelsButtonClicked()
    {
        // Activate the home screen
        SetActiveScreen(homeScreen);
    }

    private void OnReturnFromAboutButtonClicked()
    {
        // Activate the home screen
        SetActiveScreen(homeScreen);
    }

    private void OnReturnFromOptionsButtonClicked()
    {
        // Activate the home screen
        SetActiveScreen(homeScreen);
    }

    private void SetActiveScreen(GameObject activeScreen)
    {
        // Deactivate all screens
        homeScreen.SetActive(false);
        levelsScreen.SetActive(false);
        aboutScreen.SetActive(false);
        optionsScreen.SetActive(false);

        // Activate the selected screen
        activeScreen.SetActive(true);
    }

    private void LoadLevel(int buildIndex)
    {
        // Load the scene based on its build index
        SceneManager.LoadScene(buildIndex);
    }
}
