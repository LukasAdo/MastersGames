using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    public CoinGenerator coinGenerator;
    public EnemyGenerator enemyGenerator;
    public GridManager gridManager;
    public AnimalGenerator animalGenerator;
    public DoorKeyGenerator doorKeyGenerator;

    private int score = 0;
    private HashSet<string> collectedKeys = new HashSet<string>();
    private HashSet<string> collectedBrokenKeys = new HashSet<string>();

    public GameObject coinBlock;
    public Text coinBlockText;

    private int coinsCollected = 0;
    public GameObject falseKeyText;
    public GameObject trueKeyText;
    private bool keyTrueCollected = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
        DontDestroyOnLoad(gameObject); // Keep GameManager across scenes
    }

    void Start()
    {
        InitializeScene();
    }

    private void InitializeScene()
    {
        if (gridManager == null) Debug.LogError("GridManager is not assigned.");
        if (coinGenerator == null) Debug.LogError("CoinGenerator is not assigned.");
        if (enemyGenerator == null) Debug.LogError("EnemyGenerator is not assigned.");
        if (animalGenerator == null) Debug.LogError("AnimalGenerator is not assigned.");
        if (doorKeyGenerator == null) Debug.LogError("DoorKeyGenerator is not assigned.");

        // Initialize the game based on the scene
        if (IsCoinCollectionScene())
        {
            gridManager.GenerateGrid();
            coinGenerator.GenerateCoins(5);
            enemyGenerator.GenerateEnemies(3);
        }
        else if (IsSampleScene())
        {
            gridManager.GenerateGrid();
            doorKeyGenerator.GenerateKeys(1);
            doorKeyGenerator.GenerateDoors(1);
            doorKeyGenerator.GenerateBrokenKeys(1);
        }
        else if (IsAnimalScene())
        {
            gridManager.GenerateGrid();
            animalGenerator.GenerateAnimals();
        }
        else if (IsAttackScene())
        {
            gridManager.GenerateGrid();
            enemyGenerator.GenerateEnemies(3);
        }
        else
        {
            Debug.LogWarning("Unknown scene: " + SceneManager.GetActiveScene().name);
        }

        StartPlayerTurn();

        if (coinBlock != null)
        {
            coinBlock.SetActive(false);
        }
        else
        {
            Debug.LogWarning("CoinBlock is not assigned.");
        }
    }

    private bool IsCoinCollectionScene() => SceneManager.GetActiveScene().name == "CoinCollection";
    private bool IsSampleScene() => SceneManager.GetActiveScene().name == "SampleScene";
    private bool IsAnimalScene() => SceneManager.GetActiveScene().name == "AnimalScene";
    private bool IsAttackScene() => SceneManager.GetActiveScene().name == "AttackScene";

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                gridManager?.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance?.SpawnHeroes();
                break;
            case GameState.SpawnEnemies:
                enemyGenerator?.GenerateEnemies(1);
                break;
            case GameState.HeroesTurn:
                Debug.Log("Hero's turn");
                break;
            case GameState.EnemiesTurn:
                Debug.Log("Enemy's turn");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void CollectKey(string keyID)
    {
        if (!collectedKeys.Contains(keyID))
        {
            collectedKeys.Add(keyID);
            keyTrueCollected = true;
            Debug.Log("Key added: " + keyID);
            UpdateKeyBlock();
        }
    }

    public void CollectBrokenKey(string brokenKeyID)
    {
        if (!collectedBrokenKeys.Contains(brokenKeyID))
        {
            collectedBrokenKeys.Add(brokenKeyID);
            Debug.Log("Broken key collected: " + brokenKeyID);
        }
    }

    public bool HasKey(string keyID) => collectedKeys.Contains(keyID);
    public bool HasBrokenKey(string brokenKeyID) => collectedBrokenKeys.Contains(brokenKeyID);

    private void UpdateKeyBlock()
    {
        if (falseKeyText != null && trueKeyText != null)
        {
            if (keyTrueCollected)
            {
                falseKeyText.SetActive(false);
                trueKeyText.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Key text objects are not assigned.");
        }
    }

    public void StartPlayerTurn()
    {
        ChangeState(GameState.HeroesTurn);
        Debug.Log("Player's turn");
    }

    public void StartEnemyTurn()
    {
        ChangeState(GameState.EnemiesTurn);
        Debug.Log("Enemy's turn");
        StartCoroutine(EnemyTurnCoroutine());
    }

    private IEnumerator EnemyTurnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        // Perform enemy actions

        StartPlayerTurn();
    }

    public void EndPlayerTurn()
    {
        Debug.Log("End of player's turn");
        StartEnemyTurn();
    }

    public void EndEnemyTurn()
    {
        Debug.Log("End of enemy's turn");
        StartPlayerTurn();
    }

    public void SimulateEnemyTurn()
    {
        StartCoroutine(EnemyTurnCoroutine());
    }

    public void EndTurnButtonClicked()
    {
        EndPlayerTurn();
    }

    public void CollectCoin()
    {
        coinsCollected++;
        UpdateCoinBlock();
    }
    public int GetCollectedCoins()
    {
        return coinsCollected;
    }

    private void UpdateCoinBlock()
    {
        if (coinBlock != null && coinBlockText != null)
        {
            coinBlock.SetActive(coinsCollected > 0);
            coinBlockText.text = $"{coinsCollected}";
        }
        else
        {
            Debug.LogWarning("CoinBlock or CoinBlockText is not assigned.");
        }
    }

    public void FinishLevelOne()
    {
        Debug.Log("Level Finished!");
        // Implement level finish logic here (e.g., load next level, show success screen, etc.)
        SceneManager.LoadScene("HomeScreen"); // Change "NextLevel" to your next scene name
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
