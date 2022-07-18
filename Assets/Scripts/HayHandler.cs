using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class HayHandler : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            _rb.isKinematic = true;
            _rb.velocity = Vector3.zero;
        }
    }
}
