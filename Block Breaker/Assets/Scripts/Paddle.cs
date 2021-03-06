﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public bool autoPlay = false;
    private Ball ball;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        print(ball); // ispisuje loptu u konzolu ako je pronadena
    }

    // Update is called once per frame
    void Update()
    {
        if (autoPlay == false)
        {
            MoveWithmouse();
        }
        else
        {
            AutoPlay();
        }

    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);

        this.transform.position = paddlePos;
    }


    void MoveWithmouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

        this.transform.position = paddlePos;
    }
}