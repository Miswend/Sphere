using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_collectables : MonoBehaviour {

    public Text scoreText;

    private int score;


	// Use this for initialization
	void Start ()
    {
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = GetScore().ToString();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            score++;
        }

    }

    public int GetScore()
    {
        return score;
    }
}
