using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterFunctions : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("onTriggerEnter2D");
        
        //Gravity Switch
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1 * other.gameObject.GetComponent<Rigidbody2D>().gravityScale ;
        
        //Grate Settings
        other.gameObject.layer = LayerMask.NameToLayer("Water");
    }
}
