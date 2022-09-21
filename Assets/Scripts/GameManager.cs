using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeOfDay
{
    Morning,
    Afternoon,
    Night
}

public class GameManager : SingletonPattern<GameManager>
{
    private TimeOfDay timeOfDay;

    //Set singleton pattern and time of day before first frame
    protected override void Awake()
    {
        base.Awake();
        SetRandomTimeOfDay();
    }

    //Set the time of day to Morning, Afternoon, or Night randomly
    private void SetRandomTimeOfDay()
    {
        int randTimeIndex = Random.Range(0, 2);

        switch(randTimeIndex)
        {
            case 0: //Set Morning
                timeOfDay = TimeOfDay.Morning;
                break;
            case 1: //Set Afternoon
                timeOfDay = TimeOfDay.Afternoon;
                break;
            case 2: //Set Night
                timeOfDay = TimeOfDay.Night;
                break;
            default:
                Debug.LogWarning("Invalid Index for TimeOfDay!");
                timeOfDay = TimeOfDay.Morning;
                break;
        }
    }

    //Returns the current time of day
    public TimeOfDay GetTimeOfDay()
    {
        return timeOfDay;
    }
}
