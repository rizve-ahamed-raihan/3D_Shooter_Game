// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float speed = 10f;

//     private Rigidbody rb;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     void FixedUpdate()
//     {
//         float move = Input.GetAxis("Horizontal");
//         Vector3 movement = new Vector3(move * speed, 0f, 0f);
//         rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, rb.linearVelocity.z);
//     }
// }
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // A / D
        float v = Input.GetAxis("Vertical");   // W / S

        // Direction relative to where player is facing
        Vector3 move = (transform.right * h + transform.forward * v) * speed;

        rb.linearVelocity = new Vector3(move.x, 0f, move.z);
    }
}
