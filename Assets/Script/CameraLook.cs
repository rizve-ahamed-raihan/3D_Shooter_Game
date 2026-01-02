// using UnityEngine;

// public class CameraLook : MonoBehaviour
// {
//     public float mouseSensitivity = 150f;
//     public Transform player;

//     float xRotation = 0f;

//     void Start()
//     {
//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;
//     }

//     void Update()
//     {
//         float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
//         float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

//         xRotation -= mouseY;
//         xRotation = Mathf.Clamp(xRotation, -60f, 60f);

//         transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//         player.Rotate(Vector3.up * mouseX);
//     }
// }
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    public Transform player;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (player == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical look (camera only)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal look (rotate player)
        player.Rotate(Vector3.up * mouseX);
    }
}
