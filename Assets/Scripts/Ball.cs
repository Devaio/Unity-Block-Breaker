﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
    
	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        // print(paddleToBallVector.y);
        //GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {

        if (!hasStarted)
        {
            // lock ball relative to paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButton(0))
            {
                // Release the ball from the paddle
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }

        }

	}
    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.3f));
        if (hasStarted){
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
