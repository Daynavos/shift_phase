
using UnityEngine;
public class SimpleMove : MonoBehaviour
{
    public enum Phase
    {
        Ice,
        Water,
        Steam
    }
    
    public Phase phase;
    public float speed = 5f;
    public float mass = 1f;
    
    
    private Color ice_color = Color.cyan;
    private Color water_color = Color.blue;
    private Color steam_color = Color.gray;

    private LayerMask ice_layer;
    private LayerMask water_layer;
    private LayerMask steam_layer;

    private Collider2D playerCollider;
    
    void Start()
    {
        ice_layer = LayerMask.NameToLayer("Default");
        water_layer = LayerMask.NameToLayer("Water");
        steam_layer = LayerMask.NameToLayer("Steam");
        
        make_water();
        
        playerCollider = GetComponent<Collider2D>();
    }
    
    public Rigidbody2D rb;
    public float jumpAmount = 10;
    public float distanceToCheck=0.1f;
    public bool isGrounded;


    public LayerMask groundLayer; // Set this in the Inspector

    private bool jumpPressed = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        // Movement
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Ground check
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - 0.501f);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distanceToCheck);
        
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Jumping
        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        jumpPressed = false; // Reset input flag
        
        Debug.DrawRay(transform.position, Vector2.down * distanceToCheck, Color.green);

    }

    
    public void shift_phase_UP()
    {
        switch(phase) 
        {
            case Phase.Ice:
                make_water();
                break;
            case Phase.Water:
                make_steam();
                break;
            case Phase.Steam:
                break;
        }
    }

    public void shift_phase_DOWN()
    {
        switch(phase) 
        {
            case Phase.Ice:
                break;
            case Phase.Water:
                make_ice();
                break;
            case Phase.Steam:
                make_water();
                break;
        }
        
    }

    private void make_ice()
    {
        phase = Phase.Ice;
        gameObject.GetComponent<SpriteRenderer>().color = ice_color;
        gameObject.layer = ice_layer;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void make_water()
    {
        phase = Phase.Water;
        gameObject.GetComponent<SpriteRenderer>().color = water_color;
        gameObject.layer = water_layer;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void make_steam()
    {
        phase = Phase.Steam;
        gameObject.GetComponent<SpriteRenderer>().color = steam_color;
        gameObject.layer = steam_layer;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
    }

    public void acquire_mass()
    {
        transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        mass += 1f;

    }
    
}

