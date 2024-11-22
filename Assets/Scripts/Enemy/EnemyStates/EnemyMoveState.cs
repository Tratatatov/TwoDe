using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : EnemyBaseState
{
    protected const float MinChangePointDistance = 0.02f;
    protected float Speed;
    protected RaycastHit2D[] Hits;

    public EnemyMoveState(StateSwitcher switcher, NavMeshAgent agent, float speed, RaycastHit2D[] hits) : base(switcher, agent)
    {
        Speed = speed;
        Hits = hits;
    }

    public override void Enter()
    {
        Agent.speed = Speed;
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
        
    }

    public override void Update()
    {
        foreach (var hit in Hits)
        {
            if (hit.collider != null && hit.collider.CompareTag(Tags.Player))
            {
                StateSwitcher.SwitchState<EnemyFollowState>();

            }
        }
    }
}
