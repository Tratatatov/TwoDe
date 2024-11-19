using UnityEngine;

public class RotateToMoveDirection : MonoBehaviour
{
    private Vector3 m_previousPosition;

    private void Start()
    {
        m_previousPosition = transform.position;
    }

    private void Update()
    {
        Vector3 moveDirection = transform.position - m_previousPosition;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        m_previousPosition = transform.position;
    }
}