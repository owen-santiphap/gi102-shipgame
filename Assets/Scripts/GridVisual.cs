using UnityEngine;

// This script draws grid lines in the Scene view to visualize the coordinate system.
public class GridVisual : MonoBehaviour
{
    // Adjust the grid size as needed.
    public int gridSize = 10;

    void OnDrawGizmos()
    {
        // Draw grid lines (using Gizmos so they appear in the Scene view during editing and play mode)
        Gizmos.color = Color.gray;
        for (int x = -gridSize; x <= gridSize; x++)
        {
            // Draw lines parallel to the Z axis.
            Vector3 start = new Vector3(x, 0, -gridSize);
            Vector3 end = new Vector3(x, 0, gridSize);
            Gizmos.DrawLine(start, end);
        }

        for (int z = -gridSize; z <= gridSize; z++)
        {
            // Draw lines parallel to the X axis.
            Vector3 start = new Vector3(-gridSize, 0, z);
            Vector3 end = new Vector3(gridSize, 0, z);
            Gizmos.DrawLine(start, end);
        }

        // Highlight the coordinate axes:
        // X-Axis in red.
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, new Vector3(gridSize, 0, 0));

        // Z-Axis in blue.
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, new Vector3(0, 0, gridSize));
    }
}
