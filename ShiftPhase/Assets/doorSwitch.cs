using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class doorSwitch : MonoBehaviour
{
    private bool _inSwitchRange = false;
    
    private BoxCollider2D _switchCollider;
    public SpriteRenderer _switchSpriteRenderer;
    public GameObject door;

    private void Start()
    {
        _switchCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _inSwitchRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _inSwitchRange = false;
    }
    
    private void Update()
    {
        if (_inSwitchRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                door.SetActive(false);
                _switchSpriteRenderer.color = Color.gray;
            }
        }
    }
}