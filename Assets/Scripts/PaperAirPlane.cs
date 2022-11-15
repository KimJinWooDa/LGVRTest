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
    private AudioSource _audioSource;
    public AudioClip[] ac;
    public GameObject particle;
    private GameObject spawnPs;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
        _audioSource.clip = ac[0];
        _audioSource.Play();
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
            
            tr.GetComponent<YouTuberZoneBgm>().StartBGM();
            textOb.transform.position = this.transform.position;
            textOb.message = transferText;
            
           
            
            spawnPs= Instantiate(particle);
            StartCoroutine(WaitDestroy(spawnPs));
            Destroy(this.gameObject);
        }

        if (collision.collider.CompareTag("GROUND"))
        {
            trailRenderer.enabled = false;
            ps[1].Stop();
            //StartCoroutine(WaitDestroy());
        }
    }

    IEnumerator WaitDestroy(GameObject ob)
    {
        yield return new WaitForSeconds(1f);
        Destroy(ob);
    }
}
