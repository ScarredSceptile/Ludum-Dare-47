using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushCube : MonoBehaviour
{

    private Rigidbody rb;
    private AudioSource pushSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pushSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float x = other.GetContact(0).point.x - transform.position.x;
            float z = other.GetContact(0).point.z - transform.position.z;
            
            if (Mathf.Abs(x) > Mathf.Abs(z))
            {
                rb.MovePosition(new Vector3(transform.position.x - Mathf.Sign(x) * 0.5f, transform.position.y, transform.position.z));
            }
            else
            {
                rb.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z - Mathf.Sign(z) * 0.5f));
            }
            pushSound.PlayOneShot(pushSound.clip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Quad"))
        {
            EventHandler.events.CompleteEvent();
            other.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 1);
            AudioSource source = other.GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);
            Destroy(gameObject);
        }
    }
}
