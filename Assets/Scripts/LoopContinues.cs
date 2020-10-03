using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopContinues : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        EventHandler.events.wentLeft = true;
    }
}
