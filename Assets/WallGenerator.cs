using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallGenerator : MonoBehaviour {

	private int[,] borderWallsPositions = new int[4, 3] { { 0, 0, 25 }, { 25, 0, 0 }, { 50, 0, 25 }, { 25, 0, 50 } }; 
	private int[,] borderWallsRotations = new int[4, 3] { { 0, 0, 0 }, { 0, 90, 0 }, { 0, 0, 0 }, { 0, 90, 0 } };

	private int borderWallHeight = 20;
	private int borderWallLength = 50;
	private int wallHeight = 10;
	private int wallLength = 5;

	private int wallCount = 25;

	void Start ()
	{
		GameObject wall;

		// Generate walls on the borders
		GenerateBorderWalls();

		// Get player's and bots' posistions
		List<Vector3> positions = GetPositions();

		// Generate random walls inside
		GenerateWallsInside(positions);
	}

	void GenerateBorderWalls ()
	{
		Material material;
		Vector3 position, scale;
		Quaternion rotation;

		for (int i = 0; i < 4; i++) {
			material = Resources.Load ("BorderWall") as Material;
			position = new Vector3 (borderWallsPositions [i, 0], borderWallsPositions [i, 1], borderWallsPositions [i, 2]);
			scale = new Vector3 (1, borderWallHeight, borderWallLength);
			rotation = Quaternion.Euler (borderWallsRotations [i, 0], borderWallsRotations [i, 1], borderWallsRotations [i, 2]);
			GenerateWall (material, position, scale, rotation);
		}
	}

	void GenerateWallsInside (List<Vector3> objectsPositions)
	{
		int x, z, rotationDegree;
		System.Random r = new System.Random (GetHashCode());
		bool spaceEmpty = true;

		Material material;
		Vector3 position, scale;
		Quaternion rotation;

		while (wallCount > 0) {
			x = r.Next (50);
			z = r.Next (50);
			rotationDegree = r.Next (180);

			// Check if anybody is staying here
			spaceEmpty = CheckIfSpaceEmpty(x, z, objectsPositions);

			// Add a wall
			if (spaceEmpty) {
				wallCount--;
				material = Resources.Load ("Wall") as Material;
				position = new Vector3 (x, 0, z);
				scale = new Vector3 (1, wallHeight, wallLength);
				rotation = Quaternion.Euler(0, rotationDegree, 0);
				GenerateWall(material, position, scale, rotation);
			}
		}
	}

	void GenerateWall(Material material, Vector3 position, Vector3 scale, Quaternion rotation) {
		GameObject wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		wall.tag = "Wall";
		wall.GetComponent<Renderer> ().material = material;
		wall.transform.position = position;
		wall.transform.localScale = scale;
		wall.transform.rotation = rotation;
	}

	List<Vector3> GetPositions ()
	{
		List<GameObject> players = new List<GameObject>();
		players.Add(GameObject.FindWithTag("Player"));
		players.AddRange (GameObject.FindGameObjectsWithTag ("Bot1"));
		List<Vector3> positions = new List<Vector3>();

		foreach (GameObject player in players) {
			positions.Add(player.transform.position);
		}

		return positions;
	}

	bool CheckIfSpaceEmpty (int x, int z, List<Vector3> positions)
	{
		bool spaceEmpty = true;
		foreach (Vector3 position in positions) {
			if (position.x == x && position.z == z)
				spaceEmpty = false;
		}
		return spaceEmpty;
	}
}