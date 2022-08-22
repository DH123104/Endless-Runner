using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform player;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0f;
        targetPos.y = transform.position.y;
        transform.position = targetPos;
    }
}