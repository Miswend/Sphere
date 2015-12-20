using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour
{

    // Variables
    public float movementSpeed;
    public Rigidbody bullet;
    public float bulletSpeed;

    private Vector3 direction;
    private Vector3 lastDirection;
    private Rigidbody playerRigidbody;

    // Use this for initialization
    void Start()
    {
        direction = Vector3.forward;
        lastDirection = direction;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per physics calculation
    void FixedUpdate()
    {
        // Directional movement
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
            lastDirection = direction;
        }
        playerRigidbody.position += direction.normalized * movementSpeed * Time.deltaTime;


        // Fire bullet
        if (Input.GetKeyDown("space"))
        {
            Rigidbody myBullet = (Rigidbody) Instantiate(bullet, playerRigidbody.position + (lastDirection * 0.5f), Quaternion.LookRotation(lastDirection, Vector3.up));
            myBullet.velocity = lastDirection * bulletSpeed;
        }
    }
}
