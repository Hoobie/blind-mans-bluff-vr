using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SwitchCamera : MonoBehaviour
{
	List<Camera> cameras = new List<Camera>();
	private int playerCameraIdx, lastIdx = -1;
	private System.Random r;

	private float CAMERA_CHANGE_TIMEOUT = 4f;

	// Use this for initialization
	void Start ()
	{
		r = new System.Random (GetHashCode ());
		// Get all cameras
		foreach (GameObject tmp in GameObject.FindGameObjectsWithTag ("MainCamera"))
			cameras.Add (tmp.GetComponent<Camera>());

		// Change camera every CAMERA_CHANGE_TIMEOUT s
		InvokeRepeating ("ChangeCameraRandomly", 0.0f, CAMERA_CHANGE_TIMEOUT);
	}

	// Update is called once per frame
	void Update ()
	{
		//If the v button is pressed, switch to the next camera
		//Set the camera at the current index to inactive, and set the next one in the array to active
		//When we reach the end of the camera array, move back to the beginning or the array.
		if ((Input.touchCount == 0 && Input.GetKeyDown (KeyCode.V)) ||
		    (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began)) {
			ChangeCameraRandomly ();
		}
	}

	void SetCamera (int idx)
	{
		int i = 0;
		foreach (var camera in cameras) {
			if (i == idx)
				camera.enabled = true;
			else
				camera.enabled = false;
			i++;
		}
	}

	void ChangeCameraRandomly() {
		int idx = r.Next (cameras.Capacity - 1);

		// Dont't use the same camera in succession 
		while (lastIdx == idx)
			idx = r.Next (cameras.Capacity - 1);
		lastIdx = idx;
		
		SetCamera (idx);
	}
}
