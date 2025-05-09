using UnityEngine;

public class AquireMass : MonoBehaviour
{
    public AudioClip acquireMassSound; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        SimpleMove player = other.GetComponent<SimpleMove>();
        if (player != null)
        {
            player.acquire_mass();
            
            AudioSource.PlayClipAtPoint(acquireMassSound, transform.position);

            Destroy(gameObject);
        }
    }
}