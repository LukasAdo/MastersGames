using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform playerTransform; // Reference to the player's transform
    public Rigidbody2D rb;
    public GridManager gridManager; // Reference to the GridManager

    private bool isMoving = false;

    void Start()
    {
        playerTransform = FindPlayerTransform();
        rb = GetComponent<Rigidbody2D>();

        // Ensure GridManager is assigned
        if (gridManager == null)
        {
            gridManager = FindObjectOfType<GridManager>();
            if (gridManager == null)
            {
                Debug.LogError("GridManager not found in the scene.");
            }
        }
    }

    void Update()
    {
        if (GameManager.Instance.GameState == GameState.EnemiesTurn && !isMoving)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("Player transform not found.");
            return;
        }

        Vector2 currentPosition = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        Vector2 targetPosition = new Vector2(Mathf.Round(playerTransform.position.x), Mathf.Round(playerTransform.position.y));

        Tile currentTile = gridManager.GetTileAtPosition(currentPosition);
        Tile targetTile = gridManager.GetTileAtPosition(targetPosition);

        if (currentTile != null && targetTile != null)
        {
            Vector2 moveDirection = Vector2.zero;

            if (Mathf.Abs(targetPosition.x - currentPosition.x) > Mathf.Abs(targetPosition.y - currentPosition.y))
            {
                // Move horizontally
                moveDirection.x = targetPosition.x > currentPosition.x ? 1 : -1;
            }
            else
            {
                // Move vertically
                moveDirection.y = targetPosition.y > currentPosition.y ? 1 : -1;
            }

            Vector2 nextTilePosition = currentPosition + moveDirection;

            // Check if the next tile position is within bounds
            if (gridManager.IsWithinBounds(nextTilePosition))
            {
                Tile nextTile = gridManager.GetTileAtPosition(nextTilePosition);

                if (nextTile != null && nextTile.IsWalkable)
                {
                    // Move to the next tile
                    StartCoroutine(MoveEnemyCoroutine(nextTilePosition));
                }
                else
                {
                    Debug.LogWarning("Next tile is not walkable.");
                }
            }
            else
            {
                Debug.LogWarning("Next tile is out of bounds.");
            }
        }
        else
        {
            Debug.LogWarning("Enemy or player position is not on a valid tile.");
        }
    }

    IEnumerator MoveEnemyCoroutine(Vector2 targetPosition)
    {
        isMoving = true;  // Start moving
        Vector2 startPosition = transform.position;
        float journeyLength = Vector2.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            rb.MovePosition(Vector2.Lerp(startPosition, targetPosition, fractionOfJourney));
            yield return null;
        }

        // Ensure the enemy ends up exactly at the target position
        rb.MovePosition(targetPosition);
        isMoving = false; // Finish moving

        // Notify GameManager to end the enemy's turn and proceed to the next state
        GameManager.Instance.EndEnemyTurn();
    }

    Transform FindPlayerTransform()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject != null)
        {
            return playerGameObject.transform;
        }
        else
        {
            Debug.LogWarning("Player GameObject not found in the scene.");
            return null;
        }
    }
}
