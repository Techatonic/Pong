using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{
    
    Game gameScript;

    void Start(){
        gameScript = GameObject.Find("Script Manager").GetComponent<Game>();
    }
    
    void OnBecameInvisible(){
        Debug.Log("Become invisible");
        int winner = 0;
        if(transform.position.x > 0){
            winner = 1;
        }
        gameScript.PointWon(winner);
    }
    
}
