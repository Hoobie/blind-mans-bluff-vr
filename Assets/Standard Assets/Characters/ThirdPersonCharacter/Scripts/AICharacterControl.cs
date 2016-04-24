using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent (typeof(NavMeshAgent))]
	[RequireComponent (typeof(ThirdPersonCharacter))]
	public class AICharacterControl : MonoBehaviour
	{
		public NavMeshAgent agent { get; private set; }
		// the navmesh agent required for the path finding
		public ThirdPersonCharacter character { get; private set; }
		// the character we are controlling
		public Transform player;
		public Transform target;
		public bool hiding = false;

		private void Start ()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<NavMeshAgent> ();
			character = GetComponent<ThirdPersonCharacter> ();

			agent.updateRotation = false;
			agent.updatePosition = true;

			player = GameObject.FindWithTag ("Player").transform;
		}

		private void Update ()
		{
			character.transform.LookAt (player);

			if (!IsPlayerLooking () && !hiding) {
				hiding = true;
				FindClosestWall ();
				agent.SetDestination (target.position);
				if (agent.remainingDistance > agent.stoppingDistance) {
					character.Move (agent.desiredVelocity, false, false);
				}
			} else {
				hiding = false;
				MoveFromPlayer ();
			}
		}

		private bool IsPlayerLooking ()
		{
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			return Physics.Raycast (ray, out hit, 100) && hit.transform.tag == "Player";
		}

		private void FindClosestWall ()
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
			target = closest.transform;
		}

		private void MoveFromPlayer ()
		{
			Vector3 moveDirection = character.transform.position - player.position;
			float speed = 0.2f;
			character.Move (moveDirection.normalized * speed, false, false);
		}
	}
}
