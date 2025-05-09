using UnityEngine;

public class BreakTest : MonoBehaviour
{
    [SerializeField] private float _obstacleMass;
    public AudioClip breakSound; 
    public AudioClip CantBreakSound; 
    
    void OnCollisionEnter2D(Collision2D other)
    {
        SimpleMove.Phase phase = other.gameObject.GetComponent<SimpleMove>().phase;
        bool isDashing = other.gameObject.GetComponent<SimpleMove>().isDashing;
        float playerMass = other.gameObject.GetComponent<SimpleMove>().mass;

        if (playerMass >= _obstacleMass && phase == SimpleMove.Phase.Ice && isDashing )
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }
        else if (isDashing)
        {
            AudioSource.PlayClipAtPoint(CantBreakSound, transform.position);
        }
    }
}
