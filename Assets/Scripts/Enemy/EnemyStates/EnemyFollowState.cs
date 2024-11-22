using UnityEngine;
using UnityEngine.AI;


public class EnemyFollowState : EnemyMoveState
{
    private Transform m_target;

    public EnemyFollowState(StateSwitcher switcher, NavMeshAgent agent, float speed, RaycastHit2D[] hits, Transform target) : base(switcher, agent, speed, hits)
    {
        m_target = target;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void FixedUpdate()
    {

    }

    public override void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Agent.SetDestination(m_target.position);

    }


}
