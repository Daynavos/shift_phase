
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
    
    
    private Color ice_color = Color.cyan;
    private Color water_color = Color.blue;
    private Color steam_color = Color.gray;

    private LayerMask ice_layer;
    private LayerMask water_layer;
    private LayerMask steam_layer;

    void Start()
    {
        ice_layer = LayerMask.NameToLayer("Default");
        water_layer = LayerMask.NameToLayer("Water");
        steam_layer = LayerMask.NameToLayer("Steam");
        
        make_water();
    }
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
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
    
    
}

