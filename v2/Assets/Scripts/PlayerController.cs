using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // animations
    Animator animator;
    string Parameter = "State";
    int Idel=0;
    int Walk=1;
    int Jump=2;
    
    Rigidbody2D body;

    bool FacingRight=false;
    [Range(0,10)]
    public float Speed;
    [Range(0,100)]
    public float JumpAltitude;

    // Ground
    public Transform GroundCheck;
    public LayerMask Greound;
    public float radios;
    bool IsGrounded;

    AudioSource jumpSound;
    
    
    void Start() {
        body = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        IsGrounded=Physics2D.OverlapCircle(GroundCheck.position,radios,Greound);

        float MoveDirection = Input.GetAxis("Horizontal");

        if (MoveDirection==0){
            animator.SetInteger(Parameter,Idel);
        }else if (MoveDirection!=0 && IsGrounded) {
            animator.SetInteger(Parameter,Walk);
        }

        body.velocity= new Vector2 (MoveDirection*Speed,body.velocity.y);

        if (FacingRight==false&& MoveDirection>0){
            Flip();
        }else if (FacingRight==true&& MoveDirection<0){
            Flip();
        }
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.UpArrow)&&IsGrounded){
            body.velocity=Vector2.up*JumpAltitude;
            animator.SetInteger(Parameter,Jump);
            jumpSound.Play();
            
        }
    }
    void Flip(){
        FacingRight=!FacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x*=-1;
        transform.localScale=scaler;
    }
}
