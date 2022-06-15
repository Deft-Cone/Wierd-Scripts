using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    public float maxSpeed = 6f;
    public float timeZeroToMax = 2.5f;
    float accelRatePerSec;
    float forwardVelocity;
    
    private Rigidbody rb;

    void Awake()
    {
        accelRatePerSec = maxSpeed / timeZeroToMax;
        forwardVelocity = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            forwardVelocity += accelRatePerSec * Time.deltaTime;
            forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);
        }

        void LateUpdate()
        {
            rb.velocity = transform.forward * forwardVelocity;
        }
    }
}
