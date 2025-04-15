using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterFunctions : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("onTriggerEnter2D");
        
        other.gameObject.GetComponent<SimpleMove>().shift_phase_UP();
        //Turn off phase shift pad
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        
    }
}
