using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    [SerializeField]
    private TextMeshProUGUI timerText;
    private GameObject timerObj;
    public Color defaultTextColor;
    public float pulseSize = 1;

    [Header("Timer Settings")]
    public float timeDuration;
    public float criticalBoundary = 10;
    public float currentTime;
    public bool countDown = true;

    [Header("Flash Settings")]
    private float flashTimer;
    private float flashDuration = 1f;

    

    // Start is called before the first frame update
    void Start()
    {
        timerObj = GameObject.Find("Timer Text");
        RestartTimer();
        defaultTextColor = timerText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            TimesUp();
        }
        Flash();
        UpdateTimerText(currentTime);
    }

    private void RestartTimer()
    {
        currentTime = timeDuration;
    }

    private void UpdateTimerText(float time)
    {
        //float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = time % 1 * 100;

        string timeToShow = string.Format("{0:00}:{1:00}", seconds, milliseconds);

        timerText.text = timeToShow.ToString();


    }

    private void Flash()
    {
        if (criticalBoundary > currentTime && currentTime != 0)
        {
            ColorChange();
            SizeChange();
        }
            
    }

    private void ColorChange()
    {
        timerText.color = Color.Lerp(defaultTextColor, Color.red, Mathf.PingPong(Time.time, 1));        
    }

    private void SizeChange()
    {
        //Vector3 objScale = timerObj.gameObject.transform.localScale;
        timerObj.gameObject.transform.localScale = new Vector3(Mathf.PingPong(Time.time, .5f) + pulseSize, 
            Mathf.PingPong(Time.time, .5f) + pulseSize, Mathf.PingPong(Time.time, .5f) + pulseSize);
    }

    private void TimesUp()
    {
        if (currentTime != 0)
        {
            currentTime = 0;
            UpdateTimerText(currentTime);
        }
    }
}
