using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Vector3 clickTarget;
    private bool isMoving = false;

    private Transform parentComponentTransform;

    void Awake()
    {
        parentComponentTransform = transform.parent;
    }

    // Start is called before the first frame update
    void Start()
    {
        clickTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                clickTarget = new Vector3(hit.point.x, 0, hit.point.z);
                isMoving = true;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 clickDirection = new Vector3(clickTarget.x, parentComponentTransform.position.y, clickTarget.z);

        if (isMoving && Vector3.Distance(parentComponentTransform.position, clickDirection) > 0.1f)
        {

            parentComponentTransform.LookAt(clickDirection);
            parentComponentTransform.position += transform.forward * Time.deltaTime * speed;
        }
        else
        {
            isMoving = false;
        }
    }
}