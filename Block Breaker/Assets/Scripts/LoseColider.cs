using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

    private LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();  // linija objasnjena u skripti Ball        
        levelManager.LoadLevel("Lose");
    }


    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("Collision");
    //}


}
