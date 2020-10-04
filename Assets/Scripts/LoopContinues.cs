using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopContinues : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        EventHandler.events.wentLeft = true;
    }
}
