using UnityEngine;

public class SnakeBodyEnlarger : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private SnakeBodyController _controller;

    private void Start()
    {
        Increase();
    }

    public void Increase()
    {
        GameObject body = Instantiate(_bodyPrefab, _spawnPosition.position, Quaternion.identity);
        _controller.AddPart(body);
    }
}
