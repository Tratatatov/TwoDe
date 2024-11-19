using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField, Range(0, 10)] private float m_interactionDistance;
    [SerializeField] private IInteractable m_currentInteractableObject;
    [SerializeField] private LayerMask m_layerMask;
    private List<IInteractable> m_nearInteractableObjects = new();
    private CircleCollider2D m_circleCollider;
    [SerializeField] private IInteractable m_nearestInteractable = null;


    [Header("Test")]
    [SerializeField] private List<GameObject> m_interactableObjects = new();
    [SerializeField] private GameObject m_nearestObject = null;


    private void OnValidate()
    {
        if (m_circleCollider == null)
        {
            m_circleCollider = GetComponent<CircleCollider2D>();
        }

        if (m_circleCollider != null)
            m_circleCollider.radius = m_interactionDistance;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, m_interactionDistance);
        if (m_nearestObject != null)
            Gizmos.DrawSphere(m_nearestObject.transform.position, 1f);
    }


    private void Start()
    {
    }
    private void Update()
    {
        m_nearestInteractable = GetNearestInteractable(m_nearInteractableObjects);
        IInteractable currentInteractable = m_nearestInteractable;
        
        m_nearestObject = GetNearestObject(m_interactableObjects);


        
    }
    public void Interact()
    {
        m_nearestInteractable?.Interact();
    }

    private GameObject GetNearestObject(List<GameObject> interactables)
    {
        GameObject nearest = null;
        if (interactables.Count != 0)
        {
            foreach (var interactable in interactables)
            {
                if (nearest == null)
                {
                    nearest = interactable;
                }

                if (Vector2.Distance(transform.position, interactable.transform.position) <
                    Vector2.Distance(transform.position, nearest.transform.position))
                {
                    nearest = interactable;
                }
            }
        }
        return nearest;
    }
    private IInteractable GetNearestInteractable(List<IInteractable> interactables)
    {
        IInteractable nearest = null;
        if (interactables.Count != 0)
        {
            foreach (var interactable in interactables)
            {
                if (nearest == null)
                {
                    nearest = interactable;
                }

                if (Vector2.Distance(transform.position, interactable.Transform.position) <
                    Vector2.Distance(transform.position, nearest.Transform.position))
                {
                    nearest = interactable;
                }
            }
        }
        return nearest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractable>() != null)
        {
            if (HasObstacle(collision.transform) == false)
            {
                m_nearInteractableObjects.Add(collision.gameObject.GetComponent<IInteractable>());
                m_interactableObjects.Add(collision.gameObject);
                collision.GetComponent<IInteractable>().Highlight();

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractable>() != null)
        {
            m_nearInteractableObjects.Remove(collision.gameObject.GetComponent<IInteractable>());

            if (collision.gameObject == m_nearestObject)
            {
                m_nearestObject = null;
            }
            collision.GetComponent<IInteractable>().Unhighlight();
            m_interactableObjects.Remove(collision.gameObject);

        }
    }

    private bool HasObstacle(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector2.Distance(transform.position, target.position), m_layerMask);

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
