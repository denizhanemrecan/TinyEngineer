using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{
    private Camera Cam;
    private LineRenderer Line;
    public Transform FirePoint;
    void Start(){
        Cam = Camera.main;
        Line= GetComponent<LineRenderer>();
        StartLaser();
    }
    void Update(){
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, Vector2.right);
        if(hit.collider.tag=="Player"){
            Debug.Log("die!");
            hit.transform.GetComponent<PlayerController>().Dieing();
            Destroy(this.gameObject);
        }
    }
    void StartLaser(){
        Line.SetPosition(0,FirePoint.position);
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, Vector2.right);
        if (hit){
            Line.SetPosition(1,hit.point);
        }
        
    }

}
