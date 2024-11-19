using UnityEngine.AI;

public class EnemyMoveState : EnemyBaseState
{
    protected const float MinChangePointDistance = 0.02f;
    protected float Speed;


    public EnemyMoveState(StateSwitcher switcher, NavMeshAgent agent, float speed) : base(switcher, agent)
    {
        Speed = speed;
        
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
    }
}
