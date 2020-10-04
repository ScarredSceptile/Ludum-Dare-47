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
    public bool endStarted = false;

    [SerializeField]
    private int currentRoomEvents = 0;
    [SerializeField]
    private int currentRoomGoal = 2;

    private GameObject roomEvent;

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
        currentRoomEvents = 0;
        currentRoomGoal = 2;
    }

    public void CompleteEvent()
    {
        currentRoomEvents++;
        if (currentRoomEvents == currentRoomGoal)
        {
            changeRoom = true;
            currentRoomEvents = 0;

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
            int newEvent = Random.Range(0, 2);
            switch(newEvent)
            {
                case 0: ButtonEvent(); break;
                case 1: PushEvent(); break;
                default: Debug.Log("Event Range too large"); break;
            }
        }
    }

    public void SetRoomEvent()
    {
        //Remove event from previous room if there was one
        if (roomEvent != null)
        {
            Destroy(roomEvent);
            roomEvent = null;
        }

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

    [SerializeField]
    private GameObject button;

    private void ButtonEvent()
    {
        roomEvent = Instantiate(button);
        float x = Random.Range(-7, 7);
        float z = Random.Range(-3, 3);
        roomEvent.transform.position = new Vector3(x, 0.52f, z);
    }

    [SerializeField]
    private GameObject pushObject;

    private void PushEvent()
    {
        roomEvent = Instantiate(pushObject);
    }

    [SerializeField]
    private GameObject end;
    public void SpawnEnd()
    {
        roomEvent = Instantiate(end);
    }
}
