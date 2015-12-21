using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour
{

    // Variables
    public float speed;
    public Rigidbody bullet;
    public float bulletSpeed;
    public Transform barrelTransform;

    private Vector3 direction;
    private Vector3 lastDirection;
    private Rigidbody playerRigidbody;
    private Vector3 gravityVector;

    // Use this for initialization
    void Start()
    {
        direction = Vector3.forward;
        lastDirection = direction;
        playerRigidbody = GetComponent<Rigidbody>();
        gravityVector = (barrelTransform.position - playerRigidbody.position);
        gravityVector.z = 0;
        gravityVector = gravityVector.normalized;
    }

    // Update is called once per physics calculation
    void FixedUpdate()
    {
        gravityVector = (barrelTransform.position - playerRigidbody.position);
        gravityVector.z = 0;
        gravityVector = gravityVector.normalized;

        // Directional movement
        direction = Vector3.zero;
        if (Input.GetKey("left"))
        {
            direction += Vector3.Cross(gravityVector, Vector3.forward);
        }
        if (Input.GetKey("right"))
        {
            direction += Vector3.Cross(gravityVector, Vector3.back);
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
            playerRigidbody.rotation = Quaternion.LookRotation(direction, -gravityVector);
            lastDirection = direction;
        }
        playerRigidbody.position += direction.normalized * speed * Time.deltaTime;


        // Fire bullet
        if (Input.GetKeyDown("space"))
        {
            Rigidbody myBullet = (Rigidbody) Instantiate(bullet, playerRigidbody.position + (lastDirection * 0.5f), Quaternion.LookRotation(lastDirection, -gravityVector));
            myBullet.velocity = lastDirection * bulletSpeed;
        }
    }
}
