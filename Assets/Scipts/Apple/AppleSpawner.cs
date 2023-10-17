using UnityEngine.Pool;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public static AppleSpawner Instance; 

    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private MeshFilter _meshFilter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        Vector3 randomPointOnMesh = GetRandomPointOnMesh(_meshFilter.mesh);
        GameObject spawnedObject = ApplePooler.Instance.GetAppleFromPool();
        if (spawnedObject != null)
        {
            spawnedObject.transform.position = randomPointOnMesh;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }
    }

    private Vector3 GetRandomPointOnMesh(Mesh mesh)
    {
        int randomTriangle = Random.Range(0, mesh.triangles.Length / 3);

        Vector3 v1 = mesh.vertices[mesh.triangles[randomTriangle * 3]];
        Vector3 v2 = mesh.vertices[mesh.triangles[randomTriangle * 3 + 1]];
        Vector3 v3 = mesh.vertices[mesh.triangles[randomTriangle * 3 + 2]];

        float barycentricU = Random.value;
        float barycentricV = Random.value;

        if (barycentricU + barycentricV > 1)
        {
            barycentricU = 1 - barycentricU;
            barycentricV = 1 - barycentricV;
        }

        float barycentricW = 1 - barycentricU - barycentricV;

        Vector3 randomPoint = v1 * barycentricU + v2 * barycentricV + v3 * barycentricW;
        return transform.TransformPoint(randomPoint);  
    }
}
