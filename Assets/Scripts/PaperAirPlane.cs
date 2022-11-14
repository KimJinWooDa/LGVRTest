using System;
using System.Collections;
using Oculus.Interaction.Throw;
using UnityEngine;

public class PaperAirPlane : MonoBehaviour
{
    public string transferText;
    private Material[] mat;
    private Renderer _renderer;
    private ParticleSystem[] ps;
    private TrailRenderer trailRenderer;

    private void Start()
    {
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = false;
        ps = GetComponentsInChildren<ParticleSystem>();
        ps[0].Play();
        ps[1].Stop();
        _renderer = GetComponent<Renderer>();
        mat = _renderer.materials;
    }

    public void SetOnLine()
    {
        trailRenderer.enabled = true;
        ps[1].Play();
    }
    public void SetOnMaterial()
    {
        mat[1].SetFloat("_Thickness", 1.01f);
    }
    public void SetOffMaterial()
    {
        mat[1].SetFloat("_Thickness", 1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("YOUTUBER"))
        {
            Transform tr = collision.transform;
            PopUpText textOb = Instantiate(TextManager.Instance.UI).GetComponent<PopUpText>();

            textOb.transform.position = this.transform.position;
            textOb.message = transferText;

            Destroy(this.gameObject);
        }

        if (collision.collider.CompareTag("GROUND"))
        {
            trailRenderer.enabled = false;
            ps[1].Stop();
            //StartCoroutine(WaitDestroy());
        }
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
