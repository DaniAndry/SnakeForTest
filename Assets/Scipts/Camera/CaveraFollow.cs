using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _planetTransform;

    private float _distanceFromTarget = 22.0f;
    private float _smoothSpeed = 0.25f;

    private void FixedUpdate()
    {
        if (_target == null || _planetTransform == null) return;

        Vector3 toTarget = (_target.position - _planetTransform.position).normalized;
        Vector3 desiredPosition = _target.position + toTarget * _distanceFromTarget;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(_target);
    }
}
