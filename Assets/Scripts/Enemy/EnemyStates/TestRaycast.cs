using UnityEngine;
[ExecuteInEditMode]
public class Test2DRaycast : MonoBehaviour
{

    [SerializeField] private float coneAngle = 60f;
    [SerializeField] private int numRaycasts = 5;
    [SerializeField] private float raycastDistance = 10f;
    private LineRenderer lineRenderer;

    public void Look()
    {
        Vector3[] conePoints = new Vector3[numRaycasts + 2];
        conePoints[0] = transform.position;

        for (int i = 0; i < numRaycasts; i++)
        {
            float angle = coneAngle / 2 - (coneAngle / (numRaycasts - 1)) * i;
            Vector3 direction = Quaternion.Euler(0, 0, angle) * transform.up;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance);

            if (hit.collider != null)
            {
                conePoints[i + 1] = hit.point;
            }
            else
            {
                conePoints[i + 1] = transform.position + direction * raycastDistance;
            }
        }

        conePoints[numRaycasts + 1] = transform.position; // Connect the last point to the player

        lineRenderer.positionCount = numRaycasts + 2;
        lineRenderer.SetPositions(conePoints);

    }

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
    }

    private void Update()
    {
        Look();
    }


}
