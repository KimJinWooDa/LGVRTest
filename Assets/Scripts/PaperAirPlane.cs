using System;
using Oculus.Interaction.Throw;
using UnityEngine;

public class PaperAirPlane : MonoBehaviour
{
    public string transferText;
    private Material[] mat;
    private Renderer _renderer;
    private ParticleSystem ps;
    private TrailRenderer trailRenderer;
    private void Awake()
    {
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = false;
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Play();
        _renderer = GetComponent<Renderer>();
        mat = _renderer.materials;
    }

    public void SetOnLine()
    {
        trailRenderer.enabled = true;
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
    }
}
