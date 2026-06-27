using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 clickTarget;
    private bool isMoving = false;

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

        if (isMoving && Vector3.Distance(transform.position, clickTarget) > 0.1f)
        {
            transform.LookAt(clickTarget);                                          
            transform.position += transform.forward * Time.deltaTime * speed;       
        }
        else
        {
            isMoving = false;                                                       
        }
    }
}