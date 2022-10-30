using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject m_missilePrefab; // 미사일 프리팹.
    public GameObject m_target; // 도착 지점.

    [Header("미사일 기능 관련")]
    [Space(10f)]

    [Space(10f)]
    public int m_shotCount = 12; // 총 몇 개 발사할건지.
    [Range(0, 1)] public float m_interval = 0.15f;
    public int m_shotCountEveryInterval = 2; // 한번에 몇 개씩 발사할건지.

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            // Shot.
            StartCoroutine(CreateMissile());
        }
    }

    IEnumerator CreateMissile()
    {
        int _shotCount = m_shotCount;
        while (_shotCount > 0)
        {
            for(int i = 0; i < m_shotCountEveryInterval; i++)
            {
                if(_shotCount > 0)
                {
                    GameObject missile = Instantiate(m_missilePrefab);
                    missile.GetComponent<TestBezierCurve>().player = this.transform;
                    missile.GetComponent<TestBezierCurve>().target = m_target;
                    _shotCount--;
                }
            }
            yield return new WaitForSeconds(m_interval);
        }
        yield return null;
    }
}