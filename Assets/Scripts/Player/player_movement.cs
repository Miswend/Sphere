using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour
{

    //Variables
    public float movementSpeed;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("up"))
        {
            transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            transform.position += Vector3.back * movementSpeed * Time.deltaTime;
        }
    }
}
