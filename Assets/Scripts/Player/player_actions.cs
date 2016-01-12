﻿using UnityEngine;
using System.Collections;

public class player_actions : MonoBehaviour
{

    // Variables
    public float speed;
    public float switchSpeed;
    public Rigidbody bullet;
    public float bulletSpeed;
    public Vector3 trackSwitchJumpForce;

    private Vector3 direction;
    private Vector3 switchDirection;
    private Vector3 lastDirection;
    private Rigidbody playerRigidbody;
    private Transform currentTrackTransform;
    private MeshRenderer currentTrackMeshRenderer;
    private GameObject[] objectsOnTrack;

    private bool isSwitching;
    private int currentTrackNumber;
    private int maxTrackNumber;

    // Use this for initialization
    void Start()
    {
        isSwitching = false;
        currentTrackNumber = 0;
        maxTrackNumber = 3;

        direction = Vector3.forward;
        switchDirection = Vector3.zero;
        lastDirection = direction;
        playerRigidbody = GetComponent<Rigidbody>();
        currentTrackTransform = GameObject.Find("Track (" + currentTrackNumber.ToString() + ")").GetComponent<Transform>();
        currentTrackMeshRenderer = GameObject.Find("Track (" + currentTrackNumber.ToString() + ")").GetComponent<MeshRenderer>();

    }



    // Update is called once per physics calculation
    void FixedUpdate()
    {
        //left-right movement
        direction = Vector3.zero;
        if (Input.GetKey("left"))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey("right"))
        {
            direction += Vector3.right;
        }
        if (direction != Vector3.zero)
        {
            playerRigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
            lastDirection = direction;
        }
        playerRigidbody.position += direction.normalized * speed * Time.deltaTime;


        //switching tracks
        if (Input.GetKeyDown("up") 
        && !isSwitching
        && (currentTrackNumber < maxTrackNumber))
        {
            currentTrackNumber++;
            updateSwitchTrack();
            if (Input.GetKey("left shift"))
            {
                switchObjectsOnTrack(currentTrackNumber - 1);
            }
        }
        if (Input.GetKeyDown("down") 
        && !isSwitching
        && (currentTrackNumber > 0))
        {
            currentTrackNumber--;
            updateSwitchTrack();
            if (Input.GetKey("left shift"))
            {
                switchObjectsOnTrack(currentTrackNumber + 1);
            }
        }
        if (isSwitching)
        {
            jumpToTrack();
        }
        else
        {
            playerRigidbody.position += new Vector3(0f, 0f, (currentTrackTransform.position.z - playerRigidbody.position.z));
        }


        //changing track colour
        if (Input.GetKey("left shift"))
        {
            //currentTrackMeshRenderer = GameObject.Find("Track (" + currentTrackNumber.ToString() + ")").GetComponent<MeshRenderer>();
            //currentTrackMeshRenderer.material = new Material(Shader.Find("Light Blue"));
        } else
        {
            //currentTrackMeshRenderer.material = new Material(Shader.Find("Yellow"));
        }



        // Fire bullet
        if (Input.GetKeyDown("space"))
        {
            Rigidbody myBullet = (Rigidbody) Instantiate(bullet, playerRigidbody.position + (lastDirection * 0.1f), Quaternion.LookRotation(lastDirection, Vector3.up));
            myBullet.velocity = lastDirection * bulletSpeed;
        }



    }



    private void updateSwitchTrack()
    {
        currentTrackTransform = GameObject.Find("Track (" + currentTrackNumber.ToString() + ")").GetComponent<Transform>();
        switchDirection = new Vector3(0f, 0f, (currentTrackTransform.position.z - playerRigidbody.position.z)).normalized;
        playerRigidbody.AddForce(trackSwitchJumpForce * playerRigidbody.mass);
        isSwitching = true;
    }

    private void jumpToTrack()
    {
        playerRigidbody.position +=  switchDirection * switchSpeed * Time.deltaTime;

        if (switchDirection != new Vector3(0f, 0f, (currentTrackTransform.position.z - playerRigidbody.position.z)).normalized)
        {
            playerRigidbody.position += new Vector3(0f, 0f, (currentTrackTransform.position.z - playerRigidbody.position.z));
            isSwitching = false;
        }
    }

    private void switchObjectsOnTrack(int oldTrack)
    {
        objectsOnTrack = GameObject.FindGameObjectsWithTag(oldTrack.ToString());
        foreach (GameObject gameObj in objectsOnTrack)
        {
            gameObj.tag = currentTrackNumber.ToString();
        }
    }
}
