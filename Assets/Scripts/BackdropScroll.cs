using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropScroll : MonoBehaviour
{

    [SerializeField] SpriteRenderer m_renderer;
    [SerializeField] float m_speed = 1;
    [SerializeField] float offset = 0;

    void Start()
    {
        m_renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        offset += Time.deltaTime * m_speed;
        m_renderer.material.mainTextureOffset = Vector2.left * offset;
    }
}
