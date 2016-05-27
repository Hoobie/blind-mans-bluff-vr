using UnityEngine;
using System.Collections;

public class flickerController : MonoBehaviour {

	private Light thisLight;
	private Color originalColor;
	private float timePassed;
	private float changeValue;

	// Use this for initialization
	void Start () {
		thisLight = this.GetComponent<Light> ();

		if (thisLight != null)
		{
			originalColor = thisLight.color;
		}
		else
		{
			enabled = false;
			return;
		}

		changeValue = 0;
		timePassed = 0;
	}
		
	// Update is called once per frame
	void Update () {
		timePassed = Time.time;
		timePassed = timePassed - Mathf.Floor (timePassed);
		thisLight.color = originalColor * CalculateChange ();
	}

	private float CalculateChange()
	{
		changeValue = -Mathf.Sin (timePassed * Random.Range(10, 14) * Mathf.PI) * 0.05f + 0.095f;
		return changeValue;
	}
}
