using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallGenerator : MonoBehaviour {

	private int[,] borderWallsPositions = new int[4, 3] { { 0, 0, 25 }, { 25, 0, 0 }, { 50, 0, 25 }, { 25, 0, 50 } }; 
	private int[,] borderWallsRotations = new int[4, 3] { { 0, 0, 0 }, { 0, 90, 0 }, { 0, 0, 0 }, { 0, 90, 0 } };

	private int wallHeight = 20;
	private int wallLength = 50;
	private int smallerWallHeight = 10;
	private int smallerWallLength = 5;


	private int wallCount = 25;

	void Start ()
	{
		GameObject wall;

		// Generate walls on the borders
		for (int i = 0; i < 4; i++) {
			wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
			wall.tag = "Wall";
			Material material = Resources.Load ("BorderWall") as Material;
			wall.GetComponent<Renderer> ().material = material;
			wall.transform.position = new Vector3 (borderWallsPositions[i,0],borderWallsPositions[i,1],borderWallsPositions[i,2]);
			wall.transform.localScale = new Vector3 (1, wallHeight, wallLength);
			wall.transform.rotation = Quaternion.Euler(borderWallsRotations [i,0],borderWallsRotations [i,1],borderWallsRotations [i,2]);
		}

		// Get player's and bots' posistions
		List<GameObject> players = new List<GameObject>();
		players.Add(GameObject.FindWithTag("Player"));
		players.AddRange (GameObject.FindGameObjectsWithTag ("Bot1"));
		List<Vector3> positions = new List<Vector3>();

		foreach (GameObject player in players) {
			positions.Add(player.transform.position);
		}

		// Generate random walls inside
		int x, z, rotation;
		System.Random r = new System.Random (GetHashCode());
		bool spaceEmpty = true;
		while (wallCount > 0) {
			x = r.Next (50);
			z = r.Next (50);
			rotation = r.Next (180);

			// Check if anybody is staying here
			spaceEmpty = true;
			foreach (Vector3 position in positions) {
				if (position.x == x && position.z == z)
					spaceEmpty = false;
			}

			// Add a wall
			if (spaceEmpty) {
				wallCount--;
				wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
				wall.tag = "Wall";
				Material material = Resources.Load ("Wall") as Material;
				wall.GetComponent<Renderer> ().material = material;
				wall.transform.position = new Vector3 (x, 0, z);
				wall.transform.localScale = new Vector3 (1, smallerWallHeight, smallerWallLength);
				wall.transform.rotation = Quaternion.Euler(0,rotation,0);
			}
		}

	}

}