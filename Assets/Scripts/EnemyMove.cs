using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour{
    
    Game gameScript;
    
    void Start(){
        gameScript = GameObject.Find("Script Manager").GetComponent<Game>();
    }


    void Update(){
        float moveAmount = 0;
        if(transform.position.y < gameScript.ball.transform.position.y){
            moveAmount += SystemVariables.movementSpeed;
        }
        else if(transform.position.y > gameScript.ball.transform.position.y){
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
