using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;     
		public System.Random r;


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;

			r = new System.Random (Guid.NewGuid().GetHashCode());
			InvokeRepeating ("ChangeTarget", 0.0f, 1f);
        }

		private void ChangeTarget() {
			double nextDouble = r.NextDouble ();

			if (nextDouble < 0.25) 
				this.target = GameObject.Find ("Tree").transform;
			else if (nextDouble < 0.5)
				this.target = GameObject.Find ("Tree (1)").transform;
			else if (nextDouble < 0.75)
				this.target = GameObject.Find ("Tree (2)").transform;
			else
				this.target = GameObject.Find ("Tree (3)").transform;
		}


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
			
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
