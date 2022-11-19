using System;
using System.Collections;
using Oculus.Interaction.Throw;
using UnityEngine;
using DG.Tweening;

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
    public bool isGrabbed;
    public bool isThrow;
    public Transform rayPosition;
    private RaycastHit hit;
    public GameObject targetPosition;
    private GameObject targetingPoint;
    private Rigidbody rb;
    public bool isSuper;
    
    private float distance;
    [SerializeField] private float time;
    [SerializeField] private float speed;
    
    
    public enum Type
    {
        text,
        draw,
    }

    public Type airPlaneType;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        distance = Vector3.Distance(transform.position, hit.point);
        time = distance / speed;
        targetingPoint = Instantiate(targetPosition);
        mat[1].SetFloat("_Thickness", 1.01f);
    }
    public void SetOffMaterial()
    {
        UIManager.Instance.SetOnHandPose();
        Destroy(targetingPoint);
        ps[1].Stop();
        trailRenderer.enabled = false;
        mat[1].SetFloat("_Thickness", 1f);
    }

    private int count = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("YOUTUBER") && airPlaneType == Type.text)
        {
            Transform tr = collision.transform;
            if (!isSuper)
            {
                var textOb = Instantiate(TextManager.Instance.UI).GetComponent<PopUpText>();
                textOb.GetComponent<Canvas>().sortingOrder = count;
                tr.GetComponent<YouTuberZoneBgm>().StartBGM();
                textOb.transform.position = this.transform.position;
                textOb.profile = UserInfoManager.Instance.userProfileImage[UserInfoManager.Instance.currentIndex];
                textOb.name = name;
                textOb.message = transferText;
                textOb.time = DateTime.Now.ToString("HH:mm");
                textOb.GetInfo();
            }
            else
            {
                var textOb = Instantiate(TextManager.Instance.superUI).GetComponent<PopUpText>();
                textOb.GetComponent<Canvas>().sortingOrder = count;
                tr.GetComponent<YouTuberZoneBgm>().StartBGM();
                textOb.profile = UserInfoManager.Instance.userProfileImage[UserInfoManager.Instance.currentIndex];
                textOb.name = name;
                textOb.transform.position = this.transform.position;
                textOb.message = transferText;
                textOb.time = DateTime.Now.ToString("HH:mm");
                textOb.GetInfo();
            }

            count++;
            spawnPs= Instantiate(particle);
            StartCoroutine(WaitDestroy(spawnPs));
            Destroy(this.gameObject);
        }
        else if (collision.collider.CompareTag("YOUTUBER") && airPlaneType == Type.draw)
        {
            DrawManager.Instance.SetOnInks(this.transform.position);
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

    private void Update()
    {
        if (isGrabbed)
        {
            if (Physics.Raycast(this.transform.position, Vector3.forward, out hit, 1000f))
            {
                //표적? UI나오기
                targetingPoint.transform.position = hit.point;
                
            }
            else
            {
                targetingPoint.transform.position = targetingPoint.transform.position;
            }
        }

        if (isThrow)
        {
            if (Vector3.Distance(this.transform.position, hit.transform.position) > 0.1f)
            {
                transform.DOMove(hit.point, time);
        
            }
            else
            {
                isThrow = false;
            }
        }
    }
}
