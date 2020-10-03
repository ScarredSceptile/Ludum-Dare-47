using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler events;

    private void Awake()
    {
        events = this;
    }

    public bool wentLeft = false;
    public int cycle = -1;
    public bool finale = false;
    public int finalRoom = 0;
    public bool changeRoom = false;

    private int currentRoomEvents = 0;
    private int currentRoomGoal = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Setup()
    {
        wentLeft = false;
        cycle = -1;
        finale = false;
        finalRoom = 0;
        changeRoom = false;
        currentRoomGoal = 0;
        currentRoomGoal = 2;
    }

    public void CompleteEvent()
    {
        currentRoomEvents++;
        if (currentRoomEvents == currentRoomGoal)
        {
            changeRoom = true;

            //Prime Numbers just so that I have some sort of system in it
            switch(cycle)
            {
                case -1: currentRoomGoal = 2; break;
                case 0: currentRoomGoal = 3; break;
                case 1: currentRoomGoal = 5; break;
                case 2: currentRoomGoal = 7; break;
                case 3: currentRoomGoal = 11; break;
                case 4: currentRoomGoal = 13; break;
            }
        }
    }

    private void PlaceEvent(int chance, int ran)
    {
        if (ran <= chance)
        {

        }
    }

    public void SetRoomEvent()
    {
        if (!finale)
        {
            switch (cycle)
            {
                case -1: PlaceEvent(80, Random.Range(1, 101)); break;
                case 0: PlaceEvent(60, Random.Range(1, 101)); break;
                case 1: PlaceEvent(50, Random.Range(1, 101)); break;
                case 2: PlaceEvent(40, Random.Range(1, 101)); break;
                case 3: PlaceEvent(30, Random.Range(1, 101)); break;
                case 4: PlaceEvent(20, Random.Range(1, 101)); break;
                default: PlaceEvent(10, Random.Range(1, 101)); break;
            }
        }
    }

    private void ButtonEvent()
    {

    }

    private void PushEvent()
    {

    }
}
