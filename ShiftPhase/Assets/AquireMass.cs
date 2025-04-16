using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquireMass : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<SimpleMove>().acquire_mass();
        Destroy(gameObject);
    }
}
