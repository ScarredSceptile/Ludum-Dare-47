using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    private Material mat;
    private bool completed;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.color = new Color(1, 0, 0, 1);
        completed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!completed)
        {
            completed = true;
            EventHandler.events.CompleteEvent();
            mat.color = new Color(0, 1, 0, 1);
        }
    }
}
