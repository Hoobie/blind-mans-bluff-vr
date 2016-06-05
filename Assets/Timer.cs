using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public static long time;        // The player's time in milliseconds.

	Text text;                      // Reference to the Text component.
	long baseTime = 30 * 1000;

	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the time.
		time = baseTime;

		// Start counting down
		InvokeRepeating("DecreaseTimer", 0, 1);
	}


	void Update ()
	{
		// Set the displayed text to be the word "Time left" followed by the time value.
		text.text = "TIME: " + ParseTime(time);
	}

	void DecreaseTimer() {
		time -= 1000;

		if (time < 1000) {
			Scenes.Load ("FinishMenu", "Score", ScoreManager.score.ToString());
		}
	}

	string ParseTime (long time)
	{
		DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		DateTime date= start.AddMilliseconds(time).ToLocalTime();

		string result = "";

		if (date.Minute < 10)
			result += "0";

		result += date.Minute;
		result += ":";

		if (date.Second < 10)
			result += "0";

		result += date.Second;

		return result;
	}
}

