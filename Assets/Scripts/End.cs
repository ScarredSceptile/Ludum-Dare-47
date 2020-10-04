using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        EventHandler.events.endStarted = true;
    }

    private void Update()
    {
        if (EventHandler.events.endStarted)
        {
            transform.localScale *= 1 + Time.deltaTime;
            if (transform.localScale.x >= 15.7f)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().LoadEnd();
            }
        }
    }
}
