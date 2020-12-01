using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    Quaternion originalRotation;
    public float rotateSpeed = 3f;
    bool restoreRotation = true;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (restoreRotation = true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * rotateSpeed);
        }

        if (transform.rotation == originalRotation)
        {
            restoreRotation = false;
        }
    }
}
