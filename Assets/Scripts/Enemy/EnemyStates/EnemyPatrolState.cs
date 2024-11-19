using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyMoveState
{
    private List<Transform> m_patrolPoints = new();
    private int m_destinationIndex = 0;

    public EnemyPatrolState(StateSwitcher switcher, NavMeshAgent agent, float speed, List<Transform> patrolPoints) : base(switcher, agent, speed)
    {
        m_patrolPoints = patrolPoints;
    }

    public override void Enter()
    {

        GoToPoint(m_patrolPoints[m_destinationIndex]);

    }

    public override void Exit()
    {

    }

    public override void FixedUpdate()
    {

    }

    public override void Update()
    {
        if (Vector2.Distance(Agent.transform.position, m_patrolPoints[m_destinationIndex].position) <= MinChangePointDistance)
        {
            ChangeDestination();
            Switcher.SwitchState<EnemyWaitingState>();
        }
    }

    private Transform GetRandomPoint() => m_patrolPoints[Random.Range(0, m_patrolPoints.Count)];

    private void ChangeDestination()
    {
        m_destinationIndex++;

        if (m_destinationIndex >= m_patrolPoints.Count)
        {
            m_destinationIndex = 0;
        }

        //Agent.SetDestination(m_patrolPoints[m_destinationIndex].position);
    }

    //private Transform GetNextPoint()
    //{
    //    return m_patrolPoints[m_destinationIndex];
    //}

    private void GoToPoint(Transform point)
    {
        Agent.SetDestination(point.position);
    }
}
