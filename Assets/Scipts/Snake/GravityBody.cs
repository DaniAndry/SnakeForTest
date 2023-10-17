using UnityEngine;

public class GravityBody : MonoBehaviour
{
    [SerializeField] private GravityAttractor planet;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        planet.Attract(_rigidbody);
    }
}