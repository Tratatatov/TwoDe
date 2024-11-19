using UnityEngine.AI;

public class EnemyCheckPositionState : EnemyMoveState
{
    public EnemyCheckPositionState(StateSwitcher switcher, NavMeshAgent agent, float speed) : base(switcher, agent, speed)
    {

    }
    public override void Enter()
    {
        base.Enter();
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
