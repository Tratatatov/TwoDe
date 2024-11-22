using UnityEngine;

public enum MovingState
{
    Idle,
    Walk,
    Run,
    Death
}

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour, IDamageble
{
    [Header("Movement")]
    [SerializeField] private FloatingJoystick m_joystick;
    [SerializeField] private float m_speed;
    [SerializeField, Range(0, 1)] private float m_walkStateThreshold = 0.5f;
    private MovingState m_CurrentState;
    private Rigidbody2D m_rigidbody2D;
    private Vector2 m_velocity;

  

    //Visual
    private Animator m_Animator;
    private SpriteRenderer m_Renderer;
    private const string Run = "Run";
    private const string Walk = "Walk";
    private const string Death = "Death";
    private const string Idle = "Idle";

    private void Start()
    {
        m_Renderer = GetComponentInChildren<SpriteRenderer>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponentInChildren<Animator>();
      
    }

    private void Update()
    {
        switch (m_CurrentState)
        {
            case MovingState.Idle:
                IdlingActions();
                break;
            case MovingState.Walk:
                WalkingActions();
                break;
            case MovingState.Run:
                RunningActions();
                break;
            case MovingState.Death:
                DeathActions();
                break;
        }
        Flip();
    }

  

    private void FixedUpdate()
    {
        m_rigidbody2D.velocity = m_velocity * m_speed;
    }

    private void Move()
    {
        m_velocity = m_joystick.Direction;
    }
    private void Flip()
    {
        if (m_CurrentState == MovingState.Walk || m_CurrentState == MovingState.Run)
        {
            if (m_joystick.Direction.x < 0)
                m_Renderer.flipX = true;
            if (m_joystick.Direction.x > 0)
                m_Renderer.flipX = false;
        }
    }


    private void WalkingActions()
    {
        m_Animator.SetBool(Walk, true);
        m_Animator.SetBool(Run, false);
        m_Animator.SetBool(Idle, false);
        Move();

        if (m_joystick.Direction.magnitude >= m_walkStateThreshold)
        {
            m_CurrentState = MovingState.Run;
        }

        if (m_joystick.Direction == Vector2.zero)
        {
            m_CurrentState = MovingState.Idle;
        }
    }

    private void RunningActions()
    {
        m_Animator.SetBool(Run, true);
        m_Animator.SetBool(Walk, false);
        Move();

        if (m_joystick.Direction.magnitude < m_walkStateThreshold)
        {
            m_CurrentState = MovingState.Walk;
        }

        if (m_joystick.Direction == Vector2.zero)
        {
            m_CurrentState = MovingState.Idle;
        }
    }

    private void IdlingActions()
    {
        m_Animator.SetBool(Idle, true);
        m_Animator.SetBool(Walk, false);
        m_Animator.SetBool(Run, false);
        Move();
        if (m_joystick.Direction != Vector2.zero)
        {
            m_CurrentState = MovingState.Walk;
        }
    }
    private void DeathActions()
    {
        m_Animator.SetBool(Death, true);
    }

    public void GetDamage()
    {
        m_CurrentState = MovingState.Death;

    }
    private void OnEnable()
    {
        EventBus.Instance.GameOverEvent.AddListener(GetDamage);     
    }
    private void OnDisable()
    {
        EventBus.Instance.GameOverEvent.RemoveListener(GetDamage);     
    }
}
