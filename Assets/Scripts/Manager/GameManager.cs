using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;
    public CoinGenerator coinGenerator; // Reference to the CoinGenerator
    public GridManager gridManager;     // Reference to the GridManager
    public EnemyGenerator enemyGenerator; // Reference to the EnemyGenerator
    private int score = 0;

    private HashSet<string> collectedKeys = new HashSet<string>();
    private HashSet<string> collectedBrokenKeys = new HashSet<string>();
    public DoorKeyGenerator doorKeyGenerator;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);

        coinGenerator.GenerateCoins(5);
        doorKeyGenerator.GenerateKeys(1);
        doorKeyGenerator.GenerateDoors(1);
        doorKeyGenerator.GenerateBrokenKeys(1);

        enemyGenerator.GenerateEnemies(1);
        StartPlayerTurn();
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.instance.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeroes();
                break;
            case GameState.SpawnEnemies:
               
                break;
            case GameState.HeroesTurn:
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score); // Optional: Log score for debugging
        // Update UI or perform other actions based on score change
    }
    public void CollectKey(string keyID)
    {
        if (!collectedKeys.Contains(keyID))
        {
            collectedKeys.Add(keyID);
            Debug.Log("Key added: " + keyID);
        }
    }
    public void CollectBrokenKey(string brokenKeyID)
    {
        if (!collectedBrokenKeys.Contains(brokenKeyID))
        {
            collectedBrokenKeys.Add(brokenKeyID);
            Debug.Log("Broken key collected: " + brokenKeyID);
            // Additional logic if needed
        }
    }
    public bool HasKey(string keyID)
    {
        return collectedKeys.Contains(keyID);
    }
    public bool HasBrokenKey(string brokenKeyID)
    {
        return collectedBrokenKeys.Contains(brokenKeyID);
    }

    public void StartPlayerTurn()
    {
        ChangeState(GameState.HeroesTurn);
        // Additional logic for starting player's turn
        Debug.Log("Player's turn");
    }

    public void StartEnemyTurn()
    {
        ChangeState(GameState.EnemiesTurn);
        // Additional logic for starting enemy's turn
        Debug.Log("Enemy's turn");
        StartCoroutine(EnemyTurnCoroutine()); // Example: Coroutine for enemy turn actions
    }

    private IEnumerator EnemyTurnCoroutine()
    {
        // Example enemy turn actions
        yield return new WaitForSeconds(1f); // Example delay
        // Perform enemy actions, e.g., move enemies, attack, etc.

        // After enemy turn, switch back to player's turn
        StartPlayerTurn();
    }

    // Method to handle end of player's turn actions
    public void EndPlayerTurn()
    {
        // Additional logic for ending player's turn
        Debug.Log("End of player's turn");
        StartEnemyTurn(); // Start enemy's turn after player's turn ends
    }

    // Method to handle end of enemy's turn actions (if needed)
    public void EndEnemyTurn()
    {
        // Additional logic for ending enemy's turn
        Debug.Log("End of enemy's turn");
        StartPlayerTurn(); // Start player's turn after enemy's turn ends
    }

    // Method to simulate enemy turn (for demonstration)
    public void SimulateEnemyTurn()
    {
        StartCoroutine(EnemyTurnCoroutine());
    }

    // Example method for player ending their turn (to be called from UI or player actions)
    public void EndTurnButtonClicked()
    {
        EndPlayerTurn();
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemies = 2,
    HeroesTurn = 3,
    EnemiesTurn = 4
}
