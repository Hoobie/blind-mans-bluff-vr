using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class CollisionManager : MonoBehaviour {
	private Vector3 m_Move;
	private int WALL_LENGHT = 50;

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Bot1")
		{
			ScoreManager.score += 10;

			// Move the bot randomly
			MoveBot(col);
		}
		else if (col.collider.tag == "Fire")
		{
			ScoreManager.score -= 10;
		}
	}

	void MoveBot(Collision bot) {
		System.Random r = new System.Random ();
		float x_change = r.Next (5, 15) * 1.0f;
		float z_change = r.Next (5, 15) * 1.0f;
		float current_x = bot.gameObject.transform.position.x;
		float current_z = bot.gameObject.transform.position.z;

		// Check map boundaries
		if (current_x + x_change > WALL_LENGHT)
			x_change *= -1.0f;
		if (current_z + z_change > WALL_LENGHT)
			z_change *= -1.0f;

		Debug.Log ("X change: " + x_change + ", Z change: " + z_change);
		m_Move = new Vector3 (x_change, 0.0f, z_change);
		bot.gameObject.transform.position += m_Move;
	}
	
}
