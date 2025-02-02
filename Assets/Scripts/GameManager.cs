using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField inputFieldX;
    public TMP_InputField inputFieldZ;
    public TMP_Text feedbackText;

    [Header("Enemy Settings")]
    private GameObject enemyPrefab;
    public Transform enemyContainer;
    public int gridSize = 10;
    public int enemyCount = 3;

    [Header("Player Settings")]
    public Transform player;
    public float playerY = 0.5f;

    [Header("Effects")]
    public GameObject explosionFxPrefab;
    public AudioClip explosionSfx;

    private List<GameObject> _activeEnemies = new List<GameObject>();
    private int _guessCounter;

    void Start()
    {
        // Initialize guess counter
        _guessCounter = enemyCount - 1;

        // Called to spawn enemies
        SpawnInitialEnemies();
    }

    void SpawnInitialEnemies()
    {
        // Spawn enemies
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }

        // Display initial feedback
        feedbackText.text = "Enemies spawned! Enter X and Z coordinates to attack.";
    }


    //Method to spawn enemy
    private void SpawnEnemy()
    {
        // Randomly generate enemy position in the grid
        int enemyPosX = Random.Range(-gridSize, gridSize + 1);
        int enemyPosZ = Random.Range(-gridSize, gridSize + 1);
        Vector3 enemyPosition = new Vector3(enemyPosX, 0.5f, enemyPosZ);
        Quaternion enemyRotation = Quaternion.Euler(0, Random.Range(0, 2) * 90, 0); // Randomly 0 or 90 degrees

        GameObject enemy;
        if (enemyContainer != null)
            enemy = Instantiate(enemyPrefab, enemyPosition, enemyRotation, enemyContainer);
        else
            enemy = Instantiate(enemyPrefab, enemyPosition, enemyRotation);

        _activeEnemies.Add(enemy);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int x = -gridSize; x <= gridSize; x++)
        {
            Vector3 start = new Vector3(x, 0, -gridSize);
            Vector3 end = new Vector3(x, 0, gridSize);
            Gizmos.DrawLine(start, end);
        }

        for (int z = -gridSize; z <= gridSize; z++)
        {
            Vector3 start = new Vector3(-gridSize, 0, z);
            Vector3 end = new Vector3(gridSize, 0, z);
            Gizmos.DrawLine(start, end);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, new Vector3(gridSize, 0, 0));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, new Vector3(0, 0, gridSize));
    }

    public void CheckGuess()
    {
        if (int.TryParse(inputFieldX.text, out int guessX) && int.TryParse(inputFieldZ.text, out int guessZ))
        {
            if (player != null)
            {
                player.position = new Vector3(guessX, playerY, guessZ);
            }

            bool hit = false;

            for (int i = _activeEnemies.Count - 1; i >= 0; i--)
            {
                GameObject enemy = _activeEnemies[i];
                if (enemy != null)
                {
                    int enemyX = Mathf.RoundToInt(enemy.transform.position.x);
                    int enemyZ = Mathf.RoundToInt(enemy.transform.position.z);

                    if (guessX == enemyX && guessZ == enemyZ)
                    {
                        hit = true;
                        feedbackText.text = "Correct! Enemy destroyed.";

                        if (explosionFxPrefab != null)
                        {
                            GameObject effect = Instantiate(explosionFxPrefab, enemy.transform.position, Quaternion.identity);
                            Destroy(effect, 2f);
                        }

                        if (explosionSfx != null)
                        {
                            AudioSource.PlayClipAtPoint(explosionSfx, enemy.transform.position);
                        }

                        Destroy(enemy);
                        _activeEnemies.RemoveAt(i);
                    }
                }
            }

            if (_activeEnemies.Count == 0)
            {
                feedbackText.text = "All enemies destroyed! You win!";
            }
            else if (!hit)
            {
                _guessCounter--;
                if (_guessCounter <= 0)
                {
                    feedbackText.text = "Game over! You've run out of guesses.";
                }
                else
                {
                    feedbackText.text = $"Wrong guess! Try again. Remaining guesses: {_guessCounter}";
                }
            }
        }
        else
        {
            feedbackText.text = "Invalid input! Please enter valid integers.";
        }
    }
}
