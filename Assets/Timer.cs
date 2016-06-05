using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public static long time;        // The player's time in milliseconds.

	Text text;		
	long baseTime = 60 * 1000;

	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Set timer for the first time
		if (time == 0)
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
			CancelInvoke ();
			Timer.time = baseTime;
			Scenes.Load ("FinishMenu", "Score", ScoreManager.score.ToString());
		}
	}

	public static string ParseTime (long time)
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

