using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchCamera : MonoBehaviour
{
	List<Camera> cameras;
	private int playerCameraIdx;
	private System.Random r;

	// Use this for initialization
	void Start ()
	{
		cameras = new List<Camera>(Camera.allCameras);
		cameras.RemoveAll (item => item.name == "PreRender" || item.name == "PostRender");

		Camera playerCamera = cameras.Find (item => item.name == "PlayerCamera");
		playerCameraIdx = cameras.IndexOf (playerCamera);

		SetCamera (playerCameraIdx);

		r = new System.Random (GetHashCode ());
		InvokeRepeating ("ChangeCameraRandomly", 0.0f, 4f);
	}

	// Update is called once per frame
	void Update ()
	{
		//If the v button is pressed, switch to the next camera
		//Set the camera at the current index to inactive, and set the next one in the array to active
		//When we reach the end of the camera array, move back to the beginning or the array.
		if ((Input.touchCount == 0 && Input.GetKeyDown (KeyCode.V)) ||
		    (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began)) {
			int idx = r.Next (cameras.Capacity-1);
			SetCamera (idx);
		}
	}

	void SetCamera (int idx)
	{
		int i = 0;
		foreach (Camera camera in cameras) {
			if (i == idx)
				camera.enabled = true;
			else
				camera.enabled = false;
			i++;
		}
	}

	void ChangeCameraRandomly() {
		int idx = r.Next (cameras.Capacity - 1);
		SetCamera (idx);
	}
}
