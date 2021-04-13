using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] m_EnvironmentElementPrefab;
    [SerializeField] Transform m_ReferencePoint;
    [SerializeField] float m_SecondsBetweenInstances;
    [SerializeField] int m_PrefabIndex;

    private void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
    }

    IEnumerator CreateEnvironmentElement()
    {
        m_PrefabIndex = Random.Range(0, m_EnvironmentElementPrefab.Length);
        m_SecondsBetweenInstances = Random.Range(1, 3);
        Instantiate(m_EnvironmentElementPrefab[m_PrefabIndex], m_ReferencePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(m_SecondsBetweenInstances);
        CreateEnvironmentElement();
    }

}
