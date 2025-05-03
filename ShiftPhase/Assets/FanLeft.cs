using System;
using UnityEngine;

public class FanLeft : MonoBehaviour
{
    public float magnitude = 500f;
    private bool _inFanZone = false;
    private Rigidbody2D _playerRb = null;
    private Vector2 fanDirection = Vector2.left;


    private void Start()
    {
        magnitude = 500f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            _playerRb = rb;
            _inFanZone = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody == _playerRb)
        {
            _inFanZone = false;
            _playerRb = null;
            
        }
    }

    private void FixedUpdate()
    {
        if (_inFanZone && _playerRb != null)
        {
            _playerRb.AddForce(fanDirection * magnitude, ForceMode2D.Force);
        }
    }
}