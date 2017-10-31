using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {


    static MusicPlayer instance = null; // null jer napocetku ne zelimo


    void Awake()
    {
        //Debug.Log("Music player Avake " + GetInstanceID());
        if (instance != null) // ako postoji unistava sljedeci da se ne dupliciraju
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else // ako ne postoji onda zapocinje prvi a svaki sljedeci vise nije null pa se unistava na pocetnoj if pelji 
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

	//// Use this for initialization
	//void Start () {
 //       Debug.Log("Music player Start " + GetInstanceID());

        
	//}
	
	// Update is called once per frame
	void Update () {
		
	}
}
