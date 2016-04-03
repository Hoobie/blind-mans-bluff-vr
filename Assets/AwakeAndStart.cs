using System;
using UnityEngine;

public class AwakeAndStart : MonoBehaviour
{
	void Start ()
	{
		Debug.Log ("Start called.");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
}
