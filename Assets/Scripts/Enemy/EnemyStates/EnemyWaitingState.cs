using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaitingState : EnemyMoveState
{
    private RaycastHit2D m_hit;
    private float m_time;
    private MonoBehaviour m_gameObject; // для корутин

    public EnemyWaitingState(StateSwitcher switcher, NavMeshAgent agent, float speed, MonoBehaviour gameObject, float time, RaycastHit2D hit) : base(switcher, agent, speed)
    {
        m_time = time;
        m_gameObject = gameObject;
        m_hit = hit;
    }

    public override void Enter()
    {
        m_gameObject.StartCoroutine(DontMove());
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
        //if(m_hit.collider.)
    }

    private IEnumerator DontMove()
    {
        yield return new WaitForSeconds(m_time);
        Switcher.SwitchState<EnemyPatrolState>();
    }



}
