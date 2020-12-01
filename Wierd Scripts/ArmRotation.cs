using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

    public int rotationOffset = 90;

	// Update is called once per frame
	void Update () {        //subtracting the position of the player form the mouse position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();         //Normalizing the vector so that the sum will be exual to 1.

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //finding the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset); //correct offset
	}
}
