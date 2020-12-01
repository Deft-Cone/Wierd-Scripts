using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput: MonoBehaviour {

    public List<Transform> BodyParts = new List<Transform>();
    public float minDistance = 0.25f;
    public int beginSize;
    public float speed = 1;
    public float rotationSpeed = 5;

    public GameObject bodyPrefab;

    private float dis;
    private Transform curBodypart;
    public Transform prevBodypart;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        if (Input.GetKey(KeyCode.Q))
            AddBodyPart();
	}

    public void Move()
    {
        float curSpeed = speed;

        if (Input.GetKey(KeyCode.W))
            curSpeed *= 2;

        BodyParts[0].Translate(BodyParts[0].forward * curSpeed * Time.smoothDeltaTime, Space.World);


        if (Input.GetAxis("Horizontal") != 0)
            //BodyParts[0].Rotate(Vector3.up * rotationSpeed * Input.GetAxis("Horizontal"));

        if (Input.GetAxis("Vertical") != 0)
            //BodyParts[0].Rotate(Vector3.up * rotationSpeed * Input.GetAxis("Vertical"));

        for (int i = 1; i < BodyParts.Count; i++)
        {
            curBodypart = BodyParts[i];
            prevBodypart = BodyParts[i - 1];

            dis = Vector3.Distance(prevBodypart.position, curBodypart.position);

            Vector3 newpos = prevBodypart.position;

            newpos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * dis / minDistance * curSpeed;

            if (T > 0.5f)
                T = 0.5f;
            curBodypart.position = Vector3.Slerp(curBodypart.position, newpos, T);
            curBodypart.rotation = Quaternion.Slerp(curBodypart.rotation, prevBodypart.rotation, T);
        }
    }

    public void AddBodyPart()
    {
        Transform Newpart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;

        Newpart.SetParent(transform);

        BodyParts.Add(Newpart);
    }
}
