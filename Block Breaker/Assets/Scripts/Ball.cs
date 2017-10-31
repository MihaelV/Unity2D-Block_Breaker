using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    private Vector3 paddleToBallVector;

    private bool hasStarded = false;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();  // prilikom nove scene i kopiranja prefabs-a skripta automatski se automatski povezuje na objekt koji smo naveli u ovoj liniji koda
        paddleToBallVector = this.transform.position - paddle.transform.position;       // dohvacamo udaljenost izmedu lopte(ball) i playera(paddle)        
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarded)
        {
            //zaključaj udaljenost        
            this.transform.position = paddle.transform.position + paddleToBallVector;


            //Čekaj klik miša za lansiranje lopte
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, launch ball");
                hasStarded = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));        
        if (hasStarded && collision.gameObject.tag != "Breakable" && collision.gameObject.tag != "Paddle")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
            //rigidbody.velocity += tweak;
        }
    }


}
