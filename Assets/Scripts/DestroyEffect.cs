using System.Collections;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(WaitDestroy());
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

}
