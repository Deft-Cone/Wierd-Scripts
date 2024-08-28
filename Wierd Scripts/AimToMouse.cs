using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToMouse : MonoBehaviour
{
    Camera cam;

    public LayerMask mask;
    Vector3 mousePosition;

    [Header("Aim")]
    private float xMouse;
    private float yMouse;
    [SerializeField] private float range = 100f;
    private Ray ray;
    private Ray aimRay;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Draw Ray
        mousePosition = Input.mousePosition;
        mousePosition.z = range;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        Debug.DrawRay(transform.position, mousePosition - transform.position, Color.blue);
        //Aim();
        //GetName();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(mousePosition);
    }

    private Vector3 Aim()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, range))
        {
            return raycastHit.point;
        }
        else
        {
            return Input.mousePosition;
        }
    }

    private void GetName()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray2 = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray2, out hit, range, mask))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray);
    }
}
