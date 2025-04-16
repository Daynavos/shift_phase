using UnityEngine;
public class FanTest2 : MonoBehaviour
{
    public float magnitude;
    private bool _inFanZone;
    private Rigidbody2D _playerRb;

    void Start()
    {
        magnitude = 1f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        _playerRb = other.gameObject.GetComponent<Rigidbody2D>();
        _inFanZone = true;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        _inFanZone = false;
    }

    private void FixedUpdate()
    {
        if (_inFanZone)
        {
            _playerRb.AddForce(Vector2.right * magnitude, ForceMode2D.Impulse);
        }
    }
}
