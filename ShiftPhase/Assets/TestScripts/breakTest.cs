
using UnityEngine;

public class BreakTest : MonoBehaviour
{
    private float _obstacleMass;

    void Start()
    {
        _obstacleMass = 2f;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        SimpleMove.Phase phase = other.gameObject.GetComponent<SimpleMove>().phase;
        float playerMass = other.gameObject.GetComponent<SimpleMove>().mass;

        if (playerMass >= _obstacleMass && phase == SimpleMove.Phase.Ice)
        {
            Destroy(gameObject);
        }
    }
}
