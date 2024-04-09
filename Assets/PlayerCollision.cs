using UnityEngine;

public class PlayerWallCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the collided object
        switch (other.tag)
        {
            case "RightWall":
                // If collided with the right wall, stop moving right
                StopMovingRight();
                break;
            case "LeftWall":
                // If collided with the left wall, stop moving left
                StopMovingLeft();
                break;
            case "FrontWall":
                // If collided with the front wall, stop moving forward
                StopMovingForward();
                break;
            case "BottomWall":
                // If collided with the bottom wall, stop moving backward
                StopMovingBackward();
                break;
        }
    }

    private void StopMovingRight()
    {
        // Stop moving right (adjust your player movement logic accordingly)
    }

    private void StopMovingLeft()
    {
        // Stop moving left (adjust your player movement logic accordingly)
    }

    private void StopMovingForward()
    {
        // Stop moving forward (adjust your player movement logic accordingly)
    }

    private void StopMovingBackward()
    {
        // Stop moving backward (adjust your player movement logic accordingly)
    }
}
