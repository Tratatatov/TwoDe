using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private const float WaitingSpeed = 0;

    [Header("Патрулирование")]
    [Space(5)]
    [Tooltip("Скорость перемещения во время патрулирования")]
    [SerializeField] private float m_patrolSpeed;
    [SerializeField] private List<Transform> m_patrolPoints;

    [Header("Ожидание")]
    [Space(5)]
    [Tooltip("Время ожидания, когда юнит осматривается")]
    [SerializeField] private float m_waitingTime;

    [Header("Проверка")]
    [Space(5)]
    [Tooltip("Скорость перемещения во время проверки точки")]
    [SerializeField] private float m_checkSpeed;
    private Vector2 _pointToCheck;

    [Header("Преследование")]
    [Space(5)]
    private Transform m_followTarget;
    [SerializeField] private float m_followSpeed;

    private RaycastHit2D[] m_hits;
    private NavMeshAgent m_agent;
    private StateSwitcher m_stateSwitcher;
    public StateSwitcher StateSwitcher => m_stateSwitcher;
    public RaycastHit2D[] Hits => m_hits;
    public Transform FollowTarget => m_followTarget;


    public void Construct()
    {
        m_hits = GetComponent<Vision>().RaycastHits;
        m_stateSwitcher = new StateSwitcher();
        m_stateSwitcher.States.Add(new EnemyPatrolState(m_stateSwitcher, m_agent, m_patrolSpeed, m_patrolPoints, Hits));
        m_stateSwitcher.States.Add(new EnemyWaitingState(m_stateSwitcher, m_agent, WaitingSpeed, Hits, m_waitingTime, this));
        m_stateSwitcher.States.Add(new EnemyFollowState(m_stateSwitcher, m_agent, m_followSpeed, Hits, FollowTarget));
        m_stateSwitcher.States.Add(new EnemyCheckPositionState(m_stateSwitcher, m_agent, m_checkSpeed, Hits));
    }



    private void Start()
    {
        m_followTarget = ServiceLocator.Instance.Player.transform;
        m_agent = GetComponent<NavMeshAgent>();
        Construct();
        m_stateSwitcher.SwitchState<EnemyPatrolState>();
    }

    private void Update()
    {
        m_stateSwitcher.CurrentState.Update();
        Debug.Log(m_stateSwitcher.CurrentState);
    }
    private void FixedUpdate()
    {
        m_stateSwitcher.CurrentState.FixedUpdate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Player))
        {
            EventBus.Instance.GameOver();
        }
    }
}


