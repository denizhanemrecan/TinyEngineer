using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour{
    void Start(){
        
    }

    void Update(){
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            other.GetComponent<PlayerController>().Dieing();
        }
    }
}
