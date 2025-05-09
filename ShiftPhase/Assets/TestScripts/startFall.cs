using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startFall : MonoBehaviour
{
    public GameObject moveInfo;
    public GameObject player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(TutInfo());
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        player.GetComponent<SpriteRenderer>().enabled = true;
        
    }
    
    IEnumerator TutInfo()
    {
        yield return new WaitForSeconds(1);
        moveInfo.SetActive(true);
        
        Destroy(gameObject);
    }
}
