using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startFall : MonoBehaviour
{
    public GameObject moveInfo;
    public GameObject player;
    public GameObject eye1, eye2;
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(TutInfo());
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        player.GetComponent<SpriteRenderer>().enabled = true;
        eye1.GetComponent<SpriteRenderer>().enabled = true;
        eye2.GetComponent<SpriteRenderer>().enabled = true;
        
    }
    
    IEnumerator TutInfo()
    {
        yield return new WaitForSeconds(1);
        moveInfo.SetActive(true);
        
        Destroy(gameObject);
    }
}
