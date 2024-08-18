using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class KeyBlock : MoveBlock
{
    // Reference to the player
    public GameObject player;

    // Reference to the door
    public GameObject door;

    // Flag to track if the normal key has been collected
    private bool isNormalKeyCollected = false;

    void Update()
    {
        // Optionally handle updates if needed
    }

    // Override the MoveUnit method from MoveBlock
    public override void MoveUnit()
    {
        Debug.Log("MoveUnit called for KeyBlock.");

        if (isNormalKeyCollected && IsPlayerAtDoor())
        {
            Debug.Log("Normal key collected and player is at the door. Sending player to the home screen.");
            ReturnToHomeScreen();
        }
    }

    // Method to check if the player is standing at the door
    private bool IsPlayerAtDoor()
    {
        if (player == null || door == null)
        {
            Debug.LogError("Player or door reference is not assigned.");
            return false;
        }

        // Get player and door positions
        Vector2 playerPosition = new Vector2(Mathf.Round(player.transform.position.x), Mathf.Round(player.transform.position.y));
        Vector2 doorPosition = new Vector2(Mathf.Round(door.transform.position.x), Mathf.Round(door.transform.position.y));

        // Check if player is at the door
        return playerPosition == doorPosition;
    }

    // Method to handle the transition to the home screen
    private void ReturnToHomeScreen()
    {
        // Assuming "HomeScreen" is the name of the home screen scene
        SceneManager.LoadScene("HomeScreen");
    }

    // Method to set the key collection status (could be called from another script when the key is collected)
    public void SetNormalKeyCollected(bool collected)
    {
        isNormalKeyCollected = collected;
        Debug.Log($"Normal key collected status set to {isNormalKeyCollected}.");
    }
}
