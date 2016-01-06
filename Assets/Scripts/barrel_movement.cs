using UnityEngine;
using System.Collections;

public class barrel_movement : MonoBehaviour {

    public float rotationSpeed;

    private Transform barrelTransform;

	// Use this for initialization
	void Start () {
        barrelTransform = GetComponent<Transform>();
	}
	

	void FixedUpdate () {
        barrelTransform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward);
	}
}
