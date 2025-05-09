
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
    
    [SerializeField] private GameObject LevelCleared;
    
    public Sprite iceSprite;
    public Sprite waterSprite;
    public Sprite steamSprite;


    private LayerMask ice_layer;
    private LayerMask water_layer;
    private LayerMask steam_layer;

    private Collider2D playerCollider;
    
    private float targetGravity = 1f; 
    private float originalDashGravity; 

    void Start()
    {
        Time.timeScale = 1f; 

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
    private float dashingCooldown = 0.7f;
    
    public AudioClip starSound;
    
    void Update()
    {
        if (starCount == 3)
        {
            LevelCleared.SetActive(true);
            Time.timeScale = 0;
            
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

            // Flip sprite based on movement direction
            if (move > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (move < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        // Ground check

        Bounds bounds = playerCollider.bounds;
        Vector2 origin = new Vector2(bounds.center.x, bounds.min.y - 0.01f);
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
        gameObject.GetComponent<SpriteRenderer>().sprite = iceSprite;
        gameObject.layer = ice_layer;
        targetGravity = 1f;
    }

    private void make_water()
    {
        phase = Phase.Water;
        gameObject.GetComponent<SpriteRenderer>().sprite = waterSprite;
        gameObject.layer = water_layer;
        targetGravity = 1f;
    }

    private void make_steam()
    {
        phase = Phase.Steam;
        gameObject.GetComponent<SpriteRenderer>().sprite = steamSprite;
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
            AudioSource.PlayClipAtPoint(starSound, transform.position);
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

