using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour{

    void Update(){
        float moveAmount = 0;
        if(Input.GetKey(KeyCode.UpArrow)){
            moveAmount += SystemVariables.movementSpeed;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            moveAmount -= SystemVariables.movementSpeed;
        }
        
        if(transform.position.y + moveAmount > SystemVariables.upperBound){
            transform.position = new Vector3(transform.position.x, SystemVariables.upperBound, transform.position.z);
        } else if(transform.position.y + moveAmount < SystemVariables.lowerBound){
            transform.position = new Vector3(transform.position.x, SystemVariables.lowerBound, transform.position.z);
        } else{
            transform.position = new Vector3(transform.position.x, transform.position.y + moveAmount, transform.position.z);
        }

    }
    
}
