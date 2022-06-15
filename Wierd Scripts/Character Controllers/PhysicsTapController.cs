using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTapController : MonoBehaviour
{
    Rigidbody2D body;
    public float upForce;
    public float downForce;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            body.AddForce(new Vector3(0, upForce, 0), ForceMode2D.Force);
        }
        else if (Input.GetMouseButtonUp(0)) {
                body.velocity *= downForce;
            }
        }
    }