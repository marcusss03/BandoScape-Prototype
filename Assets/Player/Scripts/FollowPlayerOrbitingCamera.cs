using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowPlayerOrbitingCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Offset")]
    public Vector3 initalOffset = Vector3.zero;

    [Header("Rotation")]
    public float rotationSpeed = 180f;

    private Camera camera;
    private float yaw = 45f;

    void Awake()
    {
        camera = GetComponent<Camera>();
        camera.orthographic = true;
    }

    private void Start()
    {
        transform.position = new Vector3(target.position.x + initalOffset.x, target.position.y + initalOffset.y, target.position.z + initalOffset.z);
    }

    private void Update()
    {
        if (Input.GetMouseButton(2))
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
            yaw += rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            yaw -= rotationSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Quaternion rotation = Quaternion.Euler(transform.rotation.x, yaw, 0f);

        transform.position = Vector3.Lerp(
            transform.position,
            target.position + rotation * initalOffset,
            2f * Time.deltaTime);

        transform.LookAt(target);

        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            desiredRotation,
            2f * Time.deltaTime);
    }
}