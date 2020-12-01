using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScripts : MonoBehaviour
{
    public GameObject[] boulder;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait; //fluctuate to decide what time increments to be spawned in
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randEnemy;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait); //waits for amount of time before executing

        while (!stop)
        {
            randEnemy = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 10, Random.Range(-spawnValues.z, spawnValues.z)); //picks where GameObject whill be spawned, keeps y at 10

            Instantiate(boulder[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation); //spawns the boulders

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
