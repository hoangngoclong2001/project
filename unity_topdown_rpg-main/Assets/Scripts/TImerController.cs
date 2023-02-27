using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    // Start is called before the first frame update
    Timer timer;
    float startTime;
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            float elapsedTime = Time.time - startTime;
            Debug.Log("Time Ran for " + elapsedTime);

            startTime = Time.time;
            timer.Run();
        }
    }
}
