using UnityEngine;

public class MehMeh : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform target;
    private void Start()
    {
    }
    private void OnDrawGizmos()
    {
        if (target != null)
        {
            //Gizmos.DrawRay(transform.position,target.position - transform.position);
            //Gizmos.color = Color.cyan;
        }
    }
    void FixedUpdate()
    {

        Vector2 direction = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,Vector2.Distance(transform.position,target.position), LayerMask.GetMask("Wall"));
        if (hit.collider != null)
        {
            Debug.Log("Obstacle!");
            Debug.DrawLine(transform.position, hit.point);
        }

    }

}
