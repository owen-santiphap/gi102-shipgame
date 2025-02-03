using UnityEngine;
using TMPro;

public class GameManagerPartial : MonoBehaviour
{
    [Header("UI References")]
    // Insert Code Here

    [Header("Enemy Settings")]
    // Insert Code Here

    [Header("Player Settings")]
    // Insert Code Here


    [Header("Effect Settings")]
    public GameObject explosionFxPrefab;

    public AudioClip explosionSfx;

    // Private Variables
    // Insert Code Here

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize guess counter

        // Call function to spawn enemies
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnInitialEnemies()
    {
        // Loop check enemy count
        // Call function to spawn enemy
    }

    private void SpawnEnemy()
    {
        // Randomly generate enemy position in the grid
    }

    // Function to draw grid
    private void OnDrawGizmos()
    {

    }

    public void CheckGuess()
    {
        // Check input fields using TryParse

        // if (int.TryParse(inputFieldX.text, out int guessX) && int.TryParse(inputFieldZ.text, out int guessZ))
        // {
        //     // Move player to guess location
        //
        //     bool hit = false;
        //
        //     for (int i = _activeEnemies.Count - 1; i >= 0; i--)
        //     {
        //         GameObject enemy = _activeEnemies[i];
        //         if (enemy != null)
        //         {
        //             // Get enemies position into variables to check
        //
        //             if (***)
        //             {
        //                 hit = true;
        //                 feedbackText.text = "Correct! Enemy destroyed.";
        //
        //                 if (explosionFxPrefab != null)
        //                 {
        //                     GameObject effect = Instantiate(explosionFxPrefab, enemy.transform.position,
        //                         Quaternion.identity);
        //                     Destroy(effect, 2f);
        //                 }
        //
        //                 if (explosionSfx != null)
        //                 {
        //                     AudioSource.PlayClipAtPoint(explosionSfx, enemy.transform.position);
        //                 }
        //
        //                 Destroy(enemy);
        //                 _activeEnemies.RemoveAt(i);
        //             }
        //
        //             if (***)
        //             {
        //                 feedbackText.text = "All enemies destroyed! You win!";
        //             }
        //             else if (!hit)
        //             {
        //                 _guessCounter--;
        //                 if (_guessCounter <= 0)
        //                 {
        //                     feedbackText.text = "Game over! You've run out of guesses.";
        //                 }
        //                 else
        //                 {
        //                     feedbackText.text = $"Wrong guess! Try again. Remaining guesses: {_guessCounter}";
        //                 }
        //             }
        //         }
        //         else
        //         {
        //             feedbackText.text = "Invalid input! Please enter valid integers.";
        //         }
        //     }
        // }
    }
}
