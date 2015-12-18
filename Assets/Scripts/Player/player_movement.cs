using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour
{

    //Variables
    public float movementSpeed;

    private Vector3 direction;


    // Use this for initialization
    void Start()
    {
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        if (Input.GetKey("left"))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey("right"))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey("up"))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey("down"))
        {
            direction += Vector3.back;
        }

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        transform.position += direction * movementSpeed * Time.deltaTime;
    }
}
