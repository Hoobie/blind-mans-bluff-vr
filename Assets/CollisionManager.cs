using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class CollisionManager : MonoBehaviour {
	private Vector3 m_Move;

	void OnCollisionEnter (Collision col)
	{
		if(col.collider.tag == "Bot1")
		{
			ScoreManager.score += 10;

			// Move the bot randomly
			System.Random r = new System.Random ();
			m_Move = new Vector3 (r.Next(5, 15) * 1.0f, 0.0f, r.Next(5, 15) * 1.0f);
			col.gameObject.transform.position += m_Move;
		}
	}
	
}
