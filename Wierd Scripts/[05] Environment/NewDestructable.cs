using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDestructable : MonoBehaviour
{
    public enum BreakStyle { Shatter, Crumble };
    [SerializeField] private BreakStyle breakStyle;

    [SerializeField] private Renderer rend;
    [SerializeField] private GameObject fracturedModel;

    [SerializeField] private float breakForce = 5f;
    //[SerializeField] private float minBreakWait = 1f;
    //[SerializeField] private float maxBreakWait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //PrepareToBreak();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Replaces solid model with fractured model, and sends information depending on breakstyle selected. Shatter = all at once, Crumble = one piece at a random time between 2 floats
    /// </summary>
    /// <param name="minBreakWait">Minimum time to break off another peice</param>
    /// <param name="maxBreakWait">Maximum time to break off another piece</param>
    public void PrepareToBreak(float minBreakWait, float maxBreakWait)
    {
        Debug.Log("Preparing to Break");
        GameObject frac = Instantiate(fracturedModel, transform.position, transform.rotation);
        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;
        }
        Break(frac, minBreakWait, maxBreakWait);
    }

    public void Break(GameObject frac, float minBreakWait, float maxBreakWait)
    {
        switch (breakStyle)
        {
            case BreakStyle.Shatter:
                Shatter(frac);
                break;
            case BreakStyle.Crumble:
                StartCoroutine(Crumble(frac, minBreakWait, maxBreakWait));
                break;
        }
    }

    private void Shatter(GameObject frac)
    {
        Debug.Log("Break Style: Shatter");
        rend.enabled = false;
        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
        Destroy(gameObject);
    }

    private IEnumerator Crumble(GameObject frac, float minBreakWait, float maxBreakWait)
    {
        Debug.Log("Break Style: Crumble");
        rend.enabled = false;
        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
            float wait = Random.Range(minBreakWait, maxBreakWait);
            yield return new WaitForSeconds(wait);
        }
        Destroy(gameObject);
    }

    

    // private IEnumerator RandomBreakWait()
    // {
    //     float wait = Random.Range(minBreakWait, maxBreakWait);
    //     yield return new WaitForSeconds(wait);
    // }
}
