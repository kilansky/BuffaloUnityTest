using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Kilan Larsen
 * Description: Manages background information for the game - such as setting the time of day
 * Last Modified: 9/22/22
*/

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
        int randTimeIndex = Random.Range(0, 3);

        //Set Morning
        if (randTimeIndex == 0)
        {
            timeOfDay = TimeOfDay.Morning;
            Debug.Log("Time set to Morning");
        }
        //Set Afternoon
        else if (randTimeIndex == 1)
        {
            timeOfDay = TimeOfDay.Afternoon;
            Debug.Log("Time set to Afternoon");
        }
        //Set Night
        else if (randTimeIndex == 2)
        {
            timeOfDay = TimeOfDay.Night;
            Debug.Log("Time set to Night");
        }
        else
        {
            Debug.LogError("Invalid index given to set time of day");
        }
    }

    //Returns the current time of day
    public TimeOfDay GetTimeOfDay()
    {
        return timeOfDay;
    }
}