using UnityEngine;

public class BreakTest : MonoBehaviour
{
    [SerializeField] private float _obstacleMass;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        SimpleMove.Phase phase = other.gameObject.GetComponent<SimpleMove>().phase;
        bool isDashing = other.gameObject.GetComponent<SimpleMove>().isDashing;
        float playerMass = other.gameObject.GetComponent<SimpleMove>().mass;

        if (playerMass >= _obstacleMass && phase == SimpleMove.Phase.Ice && isDashing )
        {
            Destroy(gameObject);
        }
    }
}
