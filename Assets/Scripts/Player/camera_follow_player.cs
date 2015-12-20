using UnityEngine;
using System.Collections;

public class camera_follow_player : MonoBehaviour {

    public Transform playerTransform;

    private Vector3 offset;
    private Transform cameraTransform;

	// Use this for initialization
	void Start () {
        cameraTransform = GetComponent<Transform>();
        offset = cameraTransform.position - playerTransform.position;

    }
	
	// Update is called once per frame
	void Update () {
        cameraTransform.position = playerTransform.position + offset;
	}
}
