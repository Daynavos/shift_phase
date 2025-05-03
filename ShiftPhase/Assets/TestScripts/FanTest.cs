using UnityEngine;

public class FanTest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        SimpleMove player = other.GetComponent<SimpleMove>();
        if (player != null)
        {
            player.SetTargetGravity(1f); // Fan blows down
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        SimpleMove player = other.GetComponent<SimpleMove>();
        if (player != null && player.phase == SimpleMove.Phase.Steam)
        {
            player.SetTargetGravity(-1f); // Return to steam's default float
        }
    }
}