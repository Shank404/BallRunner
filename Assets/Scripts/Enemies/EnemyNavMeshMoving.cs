using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMoving : MonoBehaviour
{
    private float distance = 5f;
    private Transform _target;
    private Transform _transform;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _target = GameObject.Find("Ball").transform;
        _transform = transform;
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {

    }
    
    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        float distance2 = Vector3.Distance(_target.position, _transform.position);
        if (distance2 < distance)
        {
            _agent.SetDestination(_target.position);
        }
    }
}
