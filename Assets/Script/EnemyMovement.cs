using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}
