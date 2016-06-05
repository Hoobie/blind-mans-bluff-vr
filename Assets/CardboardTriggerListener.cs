using System;
using UnityEngine;
using System.Collections.Generic;

public class CardboardTriggerListener : MonoBehaviour
{
	void OnEnable() {
		Cardboard.SDK.OnTrigger += TriggerPulled;	
	}

	void OnDisable() {
		Cardboard.SDK.OnTrigger -= TriggerPulled;
	}

	void TriggerPulled() {
		Dictionary<string, string> parameters = new Dictionary<string, string> ();
		parameters.Add ("Score", ScoreManager.score.ToString());
		parameters.Add ("Time", Timer.time.ToString());
		Scenes.Load("Main", parameters);
		Scenes.Load ("PauseMenu", parameters);
	}
}

