using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        temp.transform.SetParent(transform);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        temp.name = temp.transform.GetSiblingIndex().ToString();
    }

    private void Start()
    {
        for (int i = 0; i < 16; i++)
            SpawnTile();
    }
}