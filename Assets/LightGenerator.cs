using System;
using UnityEngine;

public class LightGenerator: MonoBehaviour 
{

	void Start() 
	{
		GameObject[] walls = GameObject.FindGameObjectsWithTag ("Wall");

		foreach (GameObject wall in walls) {
			attachLight (wall);
		}
	}


	void attachLight (GameObject wall)
	{
		System.Random r = new System.Random ();

		// Create green point light
		GameObject lightGameObject = new GameObject("Light");
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = Color.green;
		lightComp.intensity = r.Next(3, 6);

		// Set it next to the wall (randomly)
		int moveX, moveY, moveZ;
		moveX = r.Next (2, 5);
		moveY = r.Next (2, 5);
		moveZ = r.Next (2, 5);

		Debug.Log (moveX + ", " + moveY + ", " + moveZ);
		lightGameObject.transform.position = wall.transform.position + new Vector3 (moveX, moveY, moveZ);
	}
}
