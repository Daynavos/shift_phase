using System;
using UnityEngine;

public class FanTest2 : MonoBehaviour
{
    public float magnitude = 10f;
    private bool _inFanZone = false;
    private Rigidbody2D _playerRb = null;
    private Vector2 fanDirection = Vector2.right;



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
            _playerRb.AddForce(Vector2.left * magnitude, ForceMode2D.Force);
        }
    }
}