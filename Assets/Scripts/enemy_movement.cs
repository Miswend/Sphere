using UnityEngine;
using System.Collections;

public class enemy_movement : MonoBehaviour {

    public float speed;
    public float roamRadius;

    private Vector3 origin;
    private Vector3 lastCorner;
    private Rigidbody enemyRigidbody;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
        enemyRigidbody = GetComponent<Rigidbody>();
        origin = enemyRigidbody.position;
        lastCorner = origin;
        direction = Vector3.forward;
	}
	
	void FixedUpdate () {
        enemyRigidbody.position += direction * speed * Time.deltaTime;

	    if ((enemyRigidbody.position - lastCorner).magnitude >= roamRadius)
        {
            direction = Vector3.Cross(direction, Vector3.up);
            enemyRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
            lastCorner = enemyRigidbody.position;
        }
	}
}
