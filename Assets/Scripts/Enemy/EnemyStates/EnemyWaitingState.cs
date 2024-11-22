using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaitingState : EnemyMoveState
{
    private float m_time;
    private MonoBehaviour m_monoBehaviour; // для корутин

    public EnemyWaitingState(StateSwitcher switcher, NavMeshAgent agent, float speed, RaycastHit2D[] hits,float time,MonoBehaviour monoBehaviour) : base(switcher, agent, speed, hits)
    {
        m_time = time;
        m_monoBehaviour = monoBehaviour;
    }

    
    public override void Enter()
    {
        m_monoBehaviour.StartCoroutine(DontMove());
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

    private void Vision()
    {
        foreach (var hit in Hits)
        {
            if (hit.collider != null && hit.collider.CompareTag(Tags.Player))
            {
                StateSwitcher.SwitchState<EnemyFollowState>();
            }
            
        }
    }

    private IEnumerator DontMove()
    {
        yield return new WaitForSeconds(m_time);
        StateSwitcher.SwitchState<EnemyPatrolState>();
    }



}
