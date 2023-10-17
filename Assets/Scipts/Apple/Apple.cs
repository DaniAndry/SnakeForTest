using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out SnakeBodyEnlarger snake))
        {
            snake.Increase();
            ReturnToPoolAndRespawn();
        }
    }

    private void ReturnToPoolAndRespawn()
    {
        ApplePooler.Instance.ReturnAppleToPool(gameObject);
        AppleSpawner.Instance.SpawnObject();  
    }
}
