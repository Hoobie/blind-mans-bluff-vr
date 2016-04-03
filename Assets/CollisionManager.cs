using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	void OnCollisionEnter (Collision col)
	{
		if(col.collider.tag == "Bot1")
		{
			ScoreManager.score += 10;
			Destroy(col.gameObject);
		}
	}
	
}
