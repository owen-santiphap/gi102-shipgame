using UnityEngine;

public class CoordinateDisplay : MonoBehaviour
{
    // Reference to the player transform.
    public Transform player;

    void OnGUI()
    {
        if (player != null)
        {
            // Get the player's position.
            Vector3 pos = player.position;
            
            // Format the coordinates to two decimal places.
            string coordinates = $"X: {pos.x:F2}   Y: {pos.y:F2}   Z: {pos.z:F2}";
            
            // Display the coordinates in the upper left corner.
            GUI.Label(new Rect(10, 10, 250, 20), coordinates);
        }
    }
}
