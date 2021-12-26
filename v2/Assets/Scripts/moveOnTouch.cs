using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnTouch : MonoBehaviour
{
    [SerializeField] 
    private Vector2 velocity;

    private bool moving;

    public Rigidbody2D rb;
    
    private void OnCollisionEnter2D(Collision2D collision) 
    { 
       if (collision.gameObject.tag == "Player") 
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        } 

        else if(collision.gameObject.tag == "socket")
        {
            collision.collider.transform.SetParent(null);
            moving = false;
        }


    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            collision.collider.transform.SetParent(null);
            moving = false;
        }

    }

    private void FixedUpdate() 
    {
        if (moving) 
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
