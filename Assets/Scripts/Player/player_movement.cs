using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour
{

    // Variables
    public float movementSpeed;

    private Vector3 direction;
    private Rigidbody playerRigidbody;

    // Use this for initialization
    void Start()
    {
        direction = Vector3.zero;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per physics calculation
    void FixedUpdate()
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
            playerRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        playerRigidbody.position += direction.normalized * movementSpeed * Time.deltaTime;
    }
}
