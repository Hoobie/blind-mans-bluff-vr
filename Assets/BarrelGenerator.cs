using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrelGenerator : MonoBehaviour {

	private static int BARREL_COUNT = 10;
	private GameObject[] barrels = new GameObject[BARREL_COUNT];

	void Start ()
	{
		// Find existing barrel with fire in it
		GameObject barrel = GameObject.Find("Barrel");

		// Copy it
		for (int i = 0; i < BARREL_COUNT; i++)
			barrels [i] = Instantiate (barrel);

		// Move it randomly
		moveRandomly(barrels);
	}

	void moveRandomly (GameObject[] barrels)
	{
		// Get player's, bots' and walls' posistions
		List<GameObject> objects = new List<GameObject>();
		objects.Add(GameObject.FindWithTag("Player"));
		objects.AddRange (GameObject.FindGameObjectsWithTag ("Bot1"));
		objects.AddRange (GameObject.FindGameObjectsWithTag ("Wall"));
		List<Bounds> bounds = new List<Bounds>();
		List<Vector3> positions = new List<Vector3> ();

		foreach (GameObject myObject in objects) {
			if (myObject.GetComponent<Renderer> () != null) {
				bounds.Add (myObject.GetComponent<Renderer> ().bounds);
				Debug.Log (myObject.name);
			}
			else
				positions.Add (myObject.transform.position);
		}

		// Move objects randomly
		int x, z;
		System.Random r = new System.Random (GetHashCode());
		bool spaceEmpty = true;
		foreach(GameObject barrel in barrels) {
			spaceEmpty = false;

			while (!spaceEmpty) {
				// Choose position
				x = r.Next (50);
				z = r.Next (50);
				spaceEmpty = true;

				// Check if anything is staying here
				foreach (Bounds objectBounds in bounds) {
					if (objectBounds.Contains(new Vector3(x, 0.0f, z)))
						spaceEmpty = false;
				}
				foreach (Vector3 position in positions) {
					if (position.x == x && position.z == z)
						spaceEmpty = false;
				}

				// Move barrel if not
				if (spaceEmpty) {
					barrel.transform.position = new Vector3 (x, 0, z);
				}
			}
		}
	}
}