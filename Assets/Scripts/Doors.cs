using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject otherDoor;
    public float xOffset;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FadeOut.fadeOut.StartFadeOut(new Vector3(otherDoor.transform.position.x + xOffset, other.transform.position.y, other.transform.position.z));
        }
    }
}
