using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float m_Speed = 5;
    [SerializeField] float m_XLimit;
  
    void Update()
    {
        transform.position += new Vector3(-1, 0, 0) * m_Speed * Time.deltaTime;
        if(transform.position.x < m_XLimit)
        {
            Destroy(gameObject);
        }
    }
}
