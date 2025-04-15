using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("onTriggerEnter2D");
        
        other.gameObject.GetComponent<SimpleMove>().shift_phase_DOWN();
        //Turn off phase shift pad
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }
}
