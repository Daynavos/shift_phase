
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimpleMove : MonoBehaviour
{
    public GameObject levelSceneManObj;
    public LevelSceneMan levelSceneMan;
    public enum Phase
    {
        Ice,
        Water,
        Steam
    }
    
    public GameObject pauseScreen;
    
    public int starCount = 0;
    
    public Phase phase;
    public float speed = 5f;
    public float mass = 1f;
    
    
    private Color ice_color = new Color(0.5f, 0.9f, 1.0f, 1.0f);    
    private Color water_color = new Color(0.0f, 0.3f, 0.8f, 1.0f);  
    private Color steam_color = new Color(0.8f, 0.8f, 0.8f, 0.5f);  


    private LayerMask ice_layer;
    private LayerMask water_layer;
    private LayerMask steam_layer;

    private Collider2D playerCollider;
    
    public string nextSceneName;
    
    private float targetGravity = 1f; 
    private float originalDashGravity; 

    void Start()
    {
        ice_layer = LayerMask.NameToLayer("Default");
        water_layer = LayerMask.NameToLayer("Water");
        steam_layer = LayerMask.NameToLayer("Steam");
        
        make_water();
        
        playerCollider = GetComponent<Collider2D>();

        levelSceneMan = levelSceneManObj.GetComponent<LevelSceneMan>();
        starCount = 0;
    }
    
    public Rigidbody2D rb;
    public float jumpAmount = 10;
    public float distanceToCheck=0.1f;
    public bool isGrounded;


    public LayerMask groundLayer; 

    private bool jumpPressed = false;
    
    private bool canDash = true;
    public bool isDashing;
    private float dashingPower = 12f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    void Update()
    {
        if (starCount == 3)
        {
            levelSceneMan.LoadScene(nextSceneName);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
        }

    }
    

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.gravityScale = targetGravity;
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }

        // Ground check
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - 0.501f);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distanceToCheck);

        isGrounded = hit.collider != null;

        // Jumping
        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        jumpPressed = false;

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
        targetGravity = 1f;
    }

    private void make_water()
    {
        phase = Phase.Water;
        gameObject.GetComponent<SpriteRenderer>().color = water_color;
        gameObject.layer = water_layer;
        targetGravity = 1f;
    }

    private void make_steam()
    {
        phase = Phase.Steam;
        gameObject.GetComponent<SpriteRenderer>().color = steam_color;
        gameObject.layer = steam_layer;
        targetGravity = -1f;
    }


    public void acquire_mass()
    {
        transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        mass += 1f;

    }
    
    public void SetTargetGravity(float newGravity)
    {
        targetGravity = newGravity;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("star"))
        {
            starCount++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("spike"))
        {
            levelSceneMan.ReloadScene();
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        originalDashGravity = targetGravity; 
        rb.gravityScale = 0f;

        float direction = Input.GetAxisRaw("Horizontal");
        if (direction == 0)
            direction = transform.localScale.x >= 0 ? 1 : -1;

        rb.velocity = new Vector2(direction * dashingPower, 0f);

        yield return new WaitForSeconds(dashingTime);

        isDashing = false;
        rb.gravityScale = originalDashGravity;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    
}

