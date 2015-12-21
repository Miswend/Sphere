using UnityEngine;
using System.Collections;

public class barrel_gravity : MonoBehaviour {

    public Transform barrelTransform;

    private static float barrelGravity = 10;
    private Rigidbody objectRigidbody;
    private Vector3 gravityVector;

	// Use this for initialization
	void Start () {
        objectRigidbody = GetComponent<Rigidbody>();
        gravityVector = (barrelTransform.position - objectRigidbody.position);
        gravityVector.z = 0;
        gravityVector = gravityVector.normalized;
    }
	
	void FixedUpdate () {
        gravityVector = (barrelTransform.position - objectRigidbody.position);
        gravityVector.z = 0;
        gravityVector = gravityVector.normalized;
        objectRigidbody.AddForceAtPosition(gravityVector.normalized * barrelGravity * objectRigidbody.mass, objectRigidbody.position);
	}
}
