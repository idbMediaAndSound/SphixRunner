using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> m_PlatformPrefab;
    [SerializeField] Transform m_PointOfReference;
    [SerializeField] GameObject m_LastCreatedPlatform;
    [SerializeField] int m_PlatformIndex;
    [SerializeField] float m_LastPlatformWidth;
    [SerializeField] float m_PlatformHeight = -2.62f;
    [SerializeField] float m_SpaceBetweenPlatforms;
    [SerializeField] float m_MinValueBetweenInstances = 1;
    [SerializeField] float m_MaxValueBetweenInstances = 4;

    void Update()
    {
        CreatePlatforms();
    }

    void CreatePlatforms()
    {
        if (m_LastCreatedPlatform.transform.position.x < m_PointOfReference.position.x)
        {
            m_PlatformIndex = Random.Range(0, m_PlatformPrefab.Count);
            m_SpaceBetweenPlatforms = Random.Range(m_MinValueBetweenInstances,m_MaxValueBetweenInstances);
            Vector3 m_TargetCreationPoint = new Vector3(m_PointOfReference.position.x + m_LastPlatformWidth + m_SpaceBetweenPlatforms, m_PlatformHeight, 0);
            m_LastCreatedPlatform = Instantiate(m_PlatformPrefab[m_PlatformIndex], m_TargetCreationPoint, Quaternion.identity);
            BoxCollider2D m_PlatformCollider = m_LastCreatedPlatform.GetComponent<BoxCollider2D>();
            m_LastPlatformWidth = m_PlatformCollider.bounds.size.x;

        }
    }
        
}
