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
        if (!FadeOut.fadeOut.started)
        {
            float x = 0;
            float z = 0;

            if (Input.GetKey(KeyCode.W))
            {
                z += Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                z -= Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                x += Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                x -= Time.deltaTime * speed;
            }

            rb.MovePosition(new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z));
        }
    }
}
