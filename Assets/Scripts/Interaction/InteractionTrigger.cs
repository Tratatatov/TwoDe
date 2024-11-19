using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerInteraction))]

public class InteractionTrigger : MonoBehaviour
{
    //[SerializeField] private List<GameObject> m_interactableObjects = new();
    //[SerializeField] private GameObject m_nearestObject = null;
    //[SerializeField] private LayerMask m_layerMask;
    //private PlayerInteraction m_playerInteraction;

    //private void Start()
    //{
    //    m_playerInteraction = GetComponent<PlayerInteraction>();
    //}
    //private void Update()
    //{
    //    if (m_interactableObjects.Count == 0) return;
    //    foreach (var interactable in m_interactableObjects)
    //    {
    //        if (m_nearestObject == null)
    //        {
    //            m_nearestObject = interactable;
    //        }

    //        if (Vector2.Distance(transform.position, interactable.transform.position) <
    //            Vector2.Distance(transform.position, m_nearestObject.transform.position))
    //        {
    //            m_nearestObject = interactable;
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<IInteractable>() != null)
    //    {
    //        if (HasObstacle(collision.transform) == false)
    //        {
    //            m_playerInteraction.NearInteractableObjects.Add(collision.gameObject.GetComponent<IInteractable>());
    //            m_interactableObjects.Add(collision.gameObject);
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<IInteractable>() != null)
    //    {
    //        m_playerInteraction.NearInteractableObjects.Remove(collision.gameObject.GetComponent<IInteractable>());

    //        if (collision.gameObject == m_nearestObject)
    //        {
    //            m_nearestObject = null;
    //        }

    //        m_interactableObjects.Remove(collision.gameObject);

    //    }
    //}

    //private bool HasObstacle(Transform target)
    //{
    //    Vector2 direction = target.position - transform.position;
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector2.Distance(transform.position, target.position), m_layerMask);

    //    if (hit.collider != null)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    //private void OnDrawGizmos()
    //{
    //    if (m_nearestObject != null)
    //        Gizmos.DrawSphere(m_nearestObject.transform.position, 1f);
    //}
}

