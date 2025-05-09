using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class spikes : MonoBehaviour
{
    public AudioClip spikeSound; 
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(HandleSpikeCollision());
    }
    
    private IEnumerator HandleSpikeCollision()
    {
        AudioSource.PlayClipAtPoint(spikeSound, transform.position);
        yield return new WaitForSeconds(1f);
        ReloadScene();
    }

}