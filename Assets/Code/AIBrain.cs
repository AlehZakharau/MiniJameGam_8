using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Code
{
    public class AIBrain : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private float walkingRadius = 5f;
        [SerializeField] private Collider catDetector;
        [SerializeField] private LayerMask cat;

        private float startSpeed;
        private void Start()
        {
            FindNewPosition();
            startSpeed = navMeshAgent.speed;
        }

        private void FindNewPosition()
        {
            var newPosition = transform.position + Random.insideUnitSphere * walkingRadius;
            navMeshAgent.SetDestination(newPosition);
        }

        private void FindNewPosition(Vector3 predatorPosition)
        {
            var newPosition = predatorPosition * -1f * 2f;
            Debug.Log($"Cat {predatorPosition} newPosition {newPosition}");
            navMeshAgent.SetDestination(newPosition);
        }

        private void Update()
        {
            if (navMeshAgent.remainingDistance < 0.1f)
            {
                FindNewPosition();
                navMeshAgent.speed = startSpeed;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer($"Cat"))
            {
                FindNewPosition(other.transform.position);
                navMeshAgent.speed *= 2;
            }
        }
    }
}