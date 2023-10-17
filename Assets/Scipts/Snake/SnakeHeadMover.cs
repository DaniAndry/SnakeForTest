using UnityEngine;

[RequireComponent(typeof(GravityBody))]
public class SnakeHeadMover : MonoBehaviour
{
    [SerializeField] private Transform _planetTransform;
    [SerializeField] private Joystick _joystick;

    private float _walkSpeed = 10;
    private float _turnSpeed = 400;

    private Rigidbody _rigidbody;

    public float WalkSpeed => _walkSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float inputX = _joystick.Horizontal;

        Vector3 currentUpDirection = (transform.position - _planetTransform.position).normalized;
        transform.RotateAround(transform.position, currentUpDirection, inputX * _turnSpeed * Time.deltaTime);

        Vector3 projectedForward = Vector3.ProjectOnPlane(transform.forward, currentUpDirection).normalized;
        transform.rotation = Quaternion.LookRotation(projectedForward, currentUpDirection);
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * _walkSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + forwardMove);
    }
}
