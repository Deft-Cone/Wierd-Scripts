using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EarthquakeEvent : MonoBehaviour
{
    public UnityEvent shock;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ShockwaveEvent()
    {
        shock.Invoke();
    }

    public void ShockwaveSingle()
    {
        Invoke("ShockwaveEvent", 0);
    }

    public void StopShockwave()
    {
        CancelInvoke();
    }

/// <summary>
/// Invokes a camera shake event after an initial delay, then randomly between two values.
/// </summary>
/// <param name="initialDelay">Time before first event is invoked</param>
/// <param name="minTimeRepeat">Minimum amount of time before next event </param>
/// <param name="maxTimeRepeat">Maximum amount of time before next event</param>
    public void ShockwaveRepeating(float initialDelay, float minTimeRepeat, float maxTimeRepeat)
    {
        InvokeRepeating("ShockwaveEvent", initialDelay, Random.Range(minTimeRepeat, maxTimeRepeat));
    }
}
