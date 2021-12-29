using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnTouch : MonoBehaviour
{
    [SerializeField] 
    private float velocity;
    public Transform SnapTransform;
    [Range(0,100)]
    public float SnapDistance;
    public Transform PlayerCol;
    private bool moving;
    //private Rigidbody2D body;
     
    void Start(){
        //body=GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D Other) { 
        // player move with platform
       if (Other.gameObject.tag == "Player") {
            PlayerCol= Other.transform;
            moving = true;
            Other.transform.SetParent(transform);
        }
        
        
        /*
        else if(collision.gameObject.tag == "socket"){
            collision.collider.transform.SetParent(null);
            moving = false;
        }
        */

    }

    private void OnCollisionExit2D(Collision2D Other) {
        if (Other.gameObject.tag == "Player") {
            Other.transform.SetParent(null);
            moving = false;
        }

    }

    private void FixedUpdate() {
        
        if (moving) {
            transform.position= new Vector2(transform.position.x+ velocity*Time.fixedDeltaTime,transform.position.y);
            //body.MovePosition(body.position + velocity * Time.fixedDeltaTime);
            //body.velocity+=velocity*Time.fixedDeltaTime;

            if (Vector2.Distance(transform.position,SnapTransform.position)<SnapDistance){
                transform.position=SnapTransform.position;
                PlayerCol.transform.SetParent(null);
                moving = false;
                Destroy(this);
            }
        }
        
    }
}
