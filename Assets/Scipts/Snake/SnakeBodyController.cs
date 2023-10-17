using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyController : MonoBehaviour
{
    [SerializeField] private int _gap;
    [SerializeField] private SnakeHeadMover _headMover;

    private List<GameObject> _bodyParts = new List<GameObject>();
    private List<Vector3> _positionsHistory = new List<Vector3>();

    public void AddPart(GameObject part)
    {
        _bodyParts.Add(part);
    }

    private void FixedUpdate()
    {
        _positionsHistory.Insert(0, _headMover.transform.position);

        int index = 0;

        foreach (var body in _bodyParts)
        {
            Vector3 point = _positionsHistory[Mathf.Clamp(index * _gap, 0, _positionsHistory.Count - 1)];

            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * _headMover.WalkSpeed * Time.deltaTime;

            Vector3 horizontalLookPoint = new Vector3(point.x, _headMover.transform.position.y, point.z);
            body.transform.LookAt(horizontalLookPoint);

            index++;
        }

        if (_positionsHistory.Count > _bodyParts.Count * _gap + 1)
        {
            _positionsHistory.RemoveAt(_positionsHistory.Count - 1);
        }
    }
}