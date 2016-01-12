using UnityEngine;
using System.Collections;

public class on_track_behaviour : MonoBehaviour {

    public float switchSpeed;
    public Vector3 switchJumpForce;

    private Rigidbody myRigidbody;
    private Transform currentTrackTransform;
    private Vector3 switchDirection;
    private bool isSwitching;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        currentTrackTransform = GameObject.Find("Track (" + tag + ")").GetComponent<Transform>();
        switchDirection = Vector3.zero;
        isSwitching = false;
    }


	void FixedUpdate () {

        currentTrackTransform = GameObject.Find("Track (" + tag + ")").GetComponent<Transform>();

        if (Mathf.Abs(currentTrackTransform.position.z - myRigidbody.position.z) > 1.5f
        && !isSwitching)
        {
            switchDirection = new Vector3(0f, 0f, (currentTrackTransform.position.z - myRigidbody.position.z)).normalized;
            myRigidbody.AddForce(switchJumpForce * myRigidbody.mass);
            isSwitching = true;
        }
        if (isSwitching)
        {
            switchTrack();
        }
    }


    private void switchTrack()
    {
        myRigidbody.position += switchDirection * switchSpeed * Time.deltaTime;

        if (switchDirection != new Vector3(0f, 0f, (currentTrackTransform.position.z - myRigidbody.position.z)).normalized)
        {
            myRigidbody.position += new Vector3(0f, 0f, (currentTrackTransform.position.z - myRigidbody.position.z));
            isSwitching = false;
        }
    }
}
