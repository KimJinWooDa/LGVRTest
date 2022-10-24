using UnityEngine;

public class WaterGravity : MonoBehaviour
{
    [SerializeField] private float gravityScale;
    private const float globalGravity = -9.81f;
    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    private void FixedUpdate()
    {
        var gravity = globalGravity * gravityScale * Vector3.up;
        rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }
}