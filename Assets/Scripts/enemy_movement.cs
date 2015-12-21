using UnityEngine;
using System.Collections;

public class enemy_movement : MonoBehaviour {

    public float speed;
    public float roamRadius;
    public float range;
    public float firerate;
    public float bulletSpeed;
    public Rigidbody bullet;
    public Collider player;

    private Vector3 origin;
    private Vector3 lastCorner;
    private Rigidbody enemyRigidbody;
    private Vector3 direction;
    private Ray myRay;
    private RaycastHit myRaycastHit;
    private float firerateCounter;

	// Use this for initialization
	void Start () {
        enemyRigidbody = GetComponent<Rigidbody>();
        origin = enemyRigidbody.position;
        lastCorner = origin;
        direction = Vector3.forward;
        myRay.direction = direction;
        myRay.origin = enemyRigidbody.position;
        firerateCounter = 0f;
    }
	
	void FixedUpdate () {
        enemyRigidbody.position += direction * speed * Time.deltaTime;

	    if ((enemyRigidbody.position - lastCorner).magnitude >= roamRadius)
        {
            direction = Vector3.Cross(direction, Vector3.up);
            enemyRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
            lastCorner = enemyRigidbody.position;
        }

        myRay.direction = direction;
        myRay.origin = enemyRigidbody.position;
        if (player.Raycast(myRay, out myRaycastHit, range) && (firerateCounter >= firerate))
        {
            Rigidbody myBullet = (Rigidbody)Instantiate(bullet, enemyRigidbody.position + (direction * 0.5f), Quaternion.LookRotation(direction, Vector3.up));
            myBullet.velocity = direction * bulletSpeed;
            firerateCounter = 0f;
        }
        firerateCounter += Time.deltaTime;
	}
}
