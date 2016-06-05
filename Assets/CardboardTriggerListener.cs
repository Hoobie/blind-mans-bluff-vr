using System;
using UnityEngine;

public class CardboardTriggerListener : MonoBehaviour
{
	void OnEnable() {
		Cardboard.SDK.OnTrigger += TriggerPulled;	
	}

	void OnDisable() {
		Cardboard.SDK.OnTrigger -= TriggerPulled;
	}

	void TriggerPulled() {
		Scenes.Load ("PauseMenu", "Score", ScoreManager.score.ToString ());
	}
}

