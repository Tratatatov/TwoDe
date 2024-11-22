using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private float m_coneAngle = 60f;
    [SerializeField] private int m_numRaycasts = 5;
    [SerializeField] private float m_raycastDistance = 10f;
    [SerializeField] private Transform m_raycastStartPoint;
    [SerializeField] private LayerMask m_layerMasks;
    private LineRenderer m_lineRenderer;
    private RaycastHit2D[] m_raycastHits;
    private Enemy m_enemy;
    public RaycastHit2D[] RaycastHits => m_raycastHits;

    private void Look()
    {
        Vector3[] conePoints = new Vector3[m_numRaycasts + 2];
        conePoints[0] = m_raycastStartPoint.position;

        m_raycastHits = new RaycastHit2D[m_numRaycasts];

        for (int i = 0; i < m_numRaycasts; i++)
        {
            float angle = m_coneAngle / 2 - (m_coneAngle / (m_numRaycasts - 1)) * i;
            Vector3 direction = Quaternion.Euler(0, 0, angle) * transform.right;
            m_raycastHits[i] = Physics2D.Raycast(m_raycastStartPoint.position, direction, m_raycastDistance, m_layerMasks);

            if (m_raycastHits[i].collider != null)
            {
                conePoints[i + 1] = m_raycastHits[i].point;
            }
            else
            {
                conePoints[i + 1] = m_raycastStartPoint.position + direction * m_raycastDistance;
            }
        }

        conePoints[m_numRaycasts + 1] = m_raycastStartPoint.position; // Connect the last point to the player

        m_lineRenderer.positionCount = m_numRaycasts + 2;
        m_lineRenderer.SetPositions(conePoints);
    }



    private void SetVisionConus()
    {
        m_lineRenderer = gameObject.AddComponent<LineRenderer>();
        m_lineRenderer.startWidth = 0.1f;
        m_lineRenderer.endWidth = 0.1f;
        m_lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        m_lineRenderer.startColor = Color.yellow;
        m_lineRenderer.endColor = Color.yellow;
    }
    private void Start()
    {
        m_enemy = GetComponent<Enemy>();
        SetVisionConus();
    }

    private void Update()
    {
        Look();
        Debugger();

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        float halfAngle = m_coneAngle / 2;
        Quaternion leftRayRotation = Quaternion.Euler(0, 0, -halfAngle);
        Quaternion rightRayRotation = Quaternion.Euler(0, 0, halfAngle);

        Vector3 leftRayDirection = leftRayRotation * transform.right;
        Vector3 rightRayDirection = rightRayRotation * transform.right;

        Gizmos.DrawRay(m_raycastStartPoint.position, leftRayDirection * m_raycastDistance);
        Gizmos.DrawRay(m_raycastStartPoint.position, rightRayDirection * m_raycastDistance);

    }

    private void Debugger()
    {
        Debug.Log(RaycastHits.Length);
        foreach (var hit in RaycastHits)
        {
            if (hit.collider != null && hit.collider.CompareTag(Tags.Player))
            {
                m_enemy.StateSwitcher.SwitchState<EnemyFollowState>();
                Debug.Log(hit.collider.name);
            }
        }
    }
}
    
