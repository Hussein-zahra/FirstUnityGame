using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [Header("Position")]
    public Vector3 offset = new Vector3(0, 3, -6);
    public float smoothSpeed = 6f;

    [Header("Rotation")]
    public float sensitivity = 120f;
    public float minY = -30f;
    public float maxY = 70f;

    private float yaw;
    private float pitch;

    private PlayerInput playerInput;
    private Vector2 lookInput;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    void LateUpdate()
    {
        if (!target || playerInput == null) return;

        lookInput = playerInput.actions["Look"].ReadValue<Vector2>();

        yaw += lookInput.x * sensitivity * Time.deltaTime;
        pitch -= lookInput.y * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minY, maxY);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 desiredPosition = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
