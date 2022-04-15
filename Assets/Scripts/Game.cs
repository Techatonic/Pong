using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour{
    
    public GameObject ball;
    Rigidbody2D ballRigidBody;

    [SerializeField]
    float ballSpeed;

    // Computer = 0
    // Player   = 1
    int[] scores = {0, 0};
    Text[] textComponents = {null, null};
    
    void Start(){
        ball = GameObject.Find("Ball");
        ballRigidBody = ball.GetComponent<Rigidbody2D>();

        textComponents[0] = GameObject.Find("Computer Score").GetComponent<Text>();
        textComponents[1] = GameObject.Find("Player Score").GetComponent<Text>();
        
        StartPoint();
    }

    void StartPoint(){
        UpdateText();

        float x = Random.Range(0.5f, 1f);
        float y = Mathf.Sqrt(1 - Mathf.Pow(x, 2));
        float plusOrMinusY = Random.Range(0, 2);
        if(plusOrMinusY == 1){
            y = -y;
        }
        StartCoroutine(ReleaseBall(x, y));
    }

    IEnumerator ReleaseBall(float x, float y){
        yield return new WaitForSeconds(0.5f);
        ballRigidBody.AddForce(new Vector2(x, y) * ballSpeed, ForceMode2D.Force);
    }


    void Update(){
        if(ball.transform.position.y >= 4.75 && ballRigidBody.velocity.y > 0 || ball.transform.position.y <= -4.75 && ballRigidBody.velocity.y < 0){
            ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
        }
    }

    void UpdateText(){
        textComponents[0].text = scores[0].ToString();
        textComponents[1].text = scores[1].ToString();
    }

    public void PointWon(int winner){
        if(winner == 0 && ++scores[0] == 10){
            EndGame("player");
            return;
        } else if(++scores[1] == 10){
            EndGame("computer");
            return;
        }

        ball.transform.position = new Vector3(0, 0, 0);
        ballRigidBody.velocity = new Vector2(0, 0);
        Start();
    }

    void EndGame(string winner){
        Debug.Log("Game over - Winner is " + winner);
    }
    
}
