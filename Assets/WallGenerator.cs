using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour
{
	private GameObject wall;
	private int[,] borderWallsPositions = new int[4, 3] { { 0, 0, 50 }, { 50, 0, 0 }, { 100, 0, 50 }, { 50, 0, 100 } }; 
	private int[,] borderWallsRotations = new int[4, 3] { { 0, 0, 0 }, { 0, 90, 0 }, { 0, 0, 0 }, { 0, 90, 0 } };
	private int wallHeight = 20;

	void Start ()
	{
		// Generate walls on the borders
		for (int i = 0; i < 4; i++) {
			wall = GameObject.CreatePrimitive (PrimitiveType.Cube);
			Material material = Resources.Load ("Wall") as Material;
			wall.GetComponent<Renderer> ().material = material;
			wall.transform.position = new Vector3 (borderWallsPositions[i,0],borderWallsPositions[i,1],borderWallsPositions[i,2]);
			wall.transform.localScale = new Vector3 (1, wallHeight, 100);
			wall.transform.rotation = Quaternion.Euler(borderWallsRotations [i,0],borderWallsRotations [i,1],borderWallsRotations [i,2]);
		}


	}

}