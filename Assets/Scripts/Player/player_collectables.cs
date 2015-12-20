using UnityEngine;
using System.Collections;

public class player_collectables : MonoBehaviour {

    // Variables


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
        }

    }
}
