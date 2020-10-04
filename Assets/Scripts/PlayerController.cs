using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FadeOut.fadeOut.started && !EventHandler.events.endStarted)
        {
            if (Input.GetKey(KeyCode.W))
            {
                float orgZ = transform.position.z;
                float z = orgZ + Time.deltaTime * speed;

                transform.position = new Vector3(transform.position.x, transform.position.y, z);
                if (Physics.CheckBox(new Vector3(transform.position.x, 1.1f, transform.position.z),new Vector3(0.24f, 0.01f, 0.24f))) 
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, orgZ);
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                float orgZ = transform.position.z;
                float z = orgZ - Time.deltaTime * speed;

                transform.position = new Vector3(transform.position.x, transform.position.y, z);
                if (Physics.CheckBox(new Vector3(transform.position.x, 1.1f, transform.position.z), new Vector3(0.25f, 0.01f, 0.25f)))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, orgZ);
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                float orgX = transform.position.x;
                float x = orgX + Time.deltaTime * speed;

                transform.position = new Vector3(x, transform.position.y, transform.position.z);
                if (Physics.CheckBox(new Vector3(transform.position.x, 1.1f, transform.position.z), new Vector3(0.25f, 0.01f, 0.25f)))
                {
                    transform.position = new Vector3(orgX, transform.position.y, transform.position.z);
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                float orgX = transform.position.x;
                float x = orgX - Time.deltaTime * speed;

                transform.position = new Vector3(x, transform.position.y, transform.position.z);
                if (Physics.CheckBox(new Vector3(transform.position.x, 1.1f, transform.position.z), new Vector3(0.25f, 0.01f, 0.25f)))
                {
                    transform.position = new Vector3(orgX, transform.position.y, transform.position.z);
                }
            }
        }
    }
}
