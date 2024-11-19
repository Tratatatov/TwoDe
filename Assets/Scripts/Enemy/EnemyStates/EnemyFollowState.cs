using UnityEngine;
using UnityEngine.AI;


public class EnemyFollowState : EnemyBaseState
{
    private RaycastHit2D m_hit;
    private Transform m_target;
    public EnemyFollowState(StateSwitcher switcher, NavMeshAgent agent, Transform target, RaycastHit2D hit) : base(switcher, agent)
    {
        m_hit = hit;
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
