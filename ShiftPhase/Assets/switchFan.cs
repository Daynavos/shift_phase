using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SwitchFan : MonoBehaviour
{
    private bool _inSwitchRange = false;
    public BoxCollider2D fanCollider;
    private BoxCollider2D _switchCollider;
    private SpriteRenderer _switchSpriteRenderer;

    private void Start()
    {
        _switchSpriteRenderer = GetComponent<SpriteRenderer>();
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

    private void turn_on_or_off()
    {
        if (fanCollider.enabled)
        {
            fanCollider.enabled = false;
            _switchCollider.enabled = false;
            _switchSpriteRenderer.color = Color.gray;
        }
        else
        {
            fanCollider.enabled = true;
            _switchCollider.enabled = false;
            _switchSpriteRenderer.color = Color.gray;
        }
    }
    private void Update()
    {
        if (_inSwitchRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                turn_on_or_off();
            }
        }
    }
}
