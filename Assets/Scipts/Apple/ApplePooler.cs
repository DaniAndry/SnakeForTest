using System.Collections.Generic;
using UnityEngine;

public class ApplePooler : MonoBehaviour
{
    public static ApplePooler Instance;

    [SerializeField] private GameObject _apple;
    [SerializeField] private int _poolSize = 20;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_apple);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public GameObject GetAppleFromPool()
    {
        if (_pool.Count == 0)
            return null; 

        GameObject obj = _pool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void ReturnAppleToPool(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }
}
