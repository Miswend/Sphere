using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

    //Variables
    private double gravity;
    

	// Use this for initialization
	void Start () {
        gravity = 0.2;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Ray ray = new Ray(transform.position, Vector3.down);

    }
}
