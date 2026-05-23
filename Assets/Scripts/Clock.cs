using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    const float hoursToDegrees = 30f, minutesToDegrees = 6f, secondsToDegrees = 6f;

    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;

    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation =
            Quaternion.Euler(hoursToDegrees * (float)time.TotalHours + 90f, 0f, -90f);
        minutesPivot.localRotation =
            Quaternion.Euler(minutesToDegrees * (float)time.TotalMinutes + 90f, 0f, -90f);
        secondsPivot.localRotation =
            Quaternion.Euler(secondsToDegrees * (float)time.TotalSeconds + 90f, 0f, -90f);

        Debug.Log(time);
    }
}