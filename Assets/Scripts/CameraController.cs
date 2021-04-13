using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform m_Player;
    [SerializeField] Vector3 m_CurrentVelocity;
    [SerializeField] float m_SmoothTime = 1f;
    [SerializeField] bool m_LookAtPLayer;
    [SerializeField] float m_BottomLimit = -2;
    [SerializeField] float m_VerticalOffset = 0;

    void Update()
    {
        if(m_Player.position.y > m_BottomLimit)
        {
            Vector3 m_TargetPosition = new Vector3(transform.position.x, m_Player.position.y + m_VerticalOffset, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, m_TargetPosition, ref m_CurrentVelocity, m_SmoothTime);
            if (m_LookAtPLayer)
            {
                transform.LookAt(m_Player);
            }
        }

    }
}
