using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(instructions());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator instructions()
    {
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
    }
}
