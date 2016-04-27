using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent (typeof(NavMeshAgent))]
	[RequireComponent (typeof(ThirdPersonCharacter))]
	public class AICharacterControl : MonoBehaviour
	{
		private ThirdPersonCharacter character;
		private Transform player;

		private void Start ()
		{
			character = GetComponent<ThirdPersonCharacter> ();
			player = GameObject.FindWithTag ("Player").transform;
		}

		private void Update ()
		{
			character.GetComponentInChildren<Camera> ().transform.LookAt (player);

			if (IsObjectCloserThan(player, 5f)) {
				Debug.Log (character.tag + " is running away!");
				MoveFromPlayer ();
			} else {
				Debug.Log (character.tag + " is hiding!");
				Transform wall = FindClosestWall ();
				if (!IsObjectCloserThan (wall, 3f)) {
					MoveToObject (wall);
				} else {
					character.Move(Vector3.zero, false, false);
				}
			}
		}

		private bool IsPlayerLooking ()
		{
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			return Physics.Raycast (ray, out hit, 10f) && hit.transform.tag == "Player";
		}

		private bool IsObjectCloserThan (Transform transform, float maxDistance)
		{
			float magnitude = (transform.position - character.transform.position).magnitude;
			return magnitude < maxDistance;
		}

		private Transform FindClosestWall ()
		{
			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag ("Wall");
			GameObject closest = null;
			float distance = Mathf.Infinity;
			Vector3 position = transform.position;
			foreach (GameObject go in gos) {
				Vector3 diff = go.transform.position - position;
				float curDistance = diff.sqrMagnitude;
				if (curDistance < distance) {
					closest = go;
					distance = curDistance;
				}
			}
			return closest.transform;
		}

		private void MoveFromPlayer ()
		{
			character.Move (character.transform.position - player.position, false, false);
		}

		private void MoveToObject (Transform transform)
		{
			character.transform.LookAt (transform);
			character.Move (character.transform.position, false, false);
		}
	}
}
