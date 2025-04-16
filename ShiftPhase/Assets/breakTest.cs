
using UnityEngine;

public class BreakTest : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<SimpleMove>().phase == SimpleMove.Phase.Ice)
        {
            Destroy(gameObject);
        }
    }
}
