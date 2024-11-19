using UnityEngine.AI;

public abstract class EnemyBaseState : State
{
    protected readonly NavMeshAgent Agent;


    public EnemyBaseState(StateSwitcher switcher,NavMeshAgent agent) : base(switcher)
    {
        Agent = agent;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    
}
