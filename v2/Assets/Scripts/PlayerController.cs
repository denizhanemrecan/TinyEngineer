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
    int Die=3;
    
    Rigidbody2D body;

    bool FacingRight=false;
    [Range(0,10)]
    public float Speed;
    [Range(0,100)]
    public float JumpAltitude;
    [Range(0,100)]
    public float FallAltitude;

    // Ground
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public float radios;
    bool IsGrounded;

    AudioSource jumpSound;
    
    
    void Start() {
        body = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        IsGrounded=Physics2D.OverlapCircle(GroundCheck.position,radios,GroundLayer);

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
            FallAltitude=-10;
            animator.SetInteger(Parameter,Jump);
            //jumpSound.Play();
        }
        if (body.velocity.y>0){
            body.velocity+=Vector2.up*Physics2D.gravity.y*FallAltitude*Time.deltaTime;
            FallAltitude++;
        }
    }
    void Flip(){
        FacingRight=!FacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x*=-1;
        transform.localScale=scaler;
    }
    public void Dieing(){
        animator.SetInteger(Parameter,Die);
    }
}
