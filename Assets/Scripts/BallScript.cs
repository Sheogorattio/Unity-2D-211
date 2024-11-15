using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    Rigidbody2D ball ;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            ball.AddForce(Vector2.up * 300 );
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            ball.AddForce(Vector2.right * 100 );
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            ball.AddForce(Vector2.left * 100 );
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            ball.AddTorque(4.4f);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            ball.angularVelocity = 0;
            ball.velocity= Vector2.zero;
        }
    }
}
