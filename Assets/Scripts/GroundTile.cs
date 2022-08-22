using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        Invoke(nameof(ResetPositon), 2f);
    }

    void ResetPositon()
    {
        Transform parentObj = transform.parent;
        Transform last_Tile = parentObj.GetChild(parentObj.childCount - 1);
        Vector3 nextPos = last_Tile.GetChild(1).position;

        transform.position = nextPos;
        transform.SetAsLastSibling();
        //groundSpawner.SpawnTile();
        //Destroy(gameObject);
    }
}