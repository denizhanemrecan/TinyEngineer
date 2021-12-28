using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropingPlatform : MonoBehaviour{
    [Range(0,20)]
    public float DropAmount=10;
    public Transform SnapTransform;
    [Range(0,100)]
    public float SnapDistance;
    void Start(){
        
    }

    void Update(){
        
    }
    private void OnCollisionEnter2D(Collision2D other) { 
        if (other.gameObject.tag == "Player" ) {
            

            if (Vector2.Distance(transform.position,SnapTransform.position)<SnapDistance){
                transform.position=SnapTransform.position;
                other.transform.SetParent(null);
                Destroy(this);
                //this.enabled=false;
            }else{
                transform.position= new Vector2(transform.position.x,
                transform.position.y- DropAmount*Time.fixedDeltaTime);
                
                other.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
       

    }
}
