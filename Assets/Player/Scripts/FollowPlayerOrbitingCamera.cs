using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowPlayerOrbitingCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Offset")]
    public Vector3 initalOffset = new Vector3(2, 2, 2);

    [Header("Rotation")]
    public float rotationSpeed = 90f;

    [Header("Zoom")]
    public float zoomSpeed = 5f;

    private Camera camera;
    private float yaw = 45f;
    private float size = 2f;

    private bool isInitialized = false;

    void Awake()
    {
        camera = GetComponent<Camera>();
        camera.orthographic = true;
    }

    public void Init(Transform? assignedTarget = null)
    {
        target = assignedTarget ?? target;
        transform.position = new Vector3(target.position.x + initalOffset.x, target.position.y + initalOffset.y, target.position.z + initalOffset.z);
        isInitialized = true;
    }

    private void Update()
    {
        if(!isInitialized)
        {
            return;
        }

        if (Input.GetMouseButton(2))
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
            yaw += rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            yaw -= rotationSpeed * Time.deltaTime;

        size -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        if (!isInitialized)
        {
            return;
        }

        Quaternion rotation = Quaternion.Euler(0f, yaw, 0f);

        transform.position = Vector3.Lerp(
            transform.position,
            target.position + rotation * initalOffset,
            2f * Time.deltaTime);

        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            desiredRotation,
            360f * Time.deltaTime);

        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, size, 2f * Time.deltaTime);
    }
}