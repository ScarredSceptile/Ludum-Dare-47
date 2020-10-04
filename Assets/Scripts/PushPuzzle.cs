using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPuzzle : MonoBehaviour
{
    private GameObject cube;
    private GameObject quad;

    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.FindGameObjectWithTag("Cube");
        quad = GameObject.FindGameObjectWithTag("Quad");

        int x1 = Random.Range(-7, 7);
        int z1 = Random.Range(-3, 3);
        cube.transform.position = new Vector3(x1, 0.75f, z1);

        int x2;
        int z2;
        do
        {
            x2 = Random.Range(-7, 7);
            z2 = Random.Range(-3, 3);
        } while (x2 == x1 && z2 == z1);
         
        quad.transform.position = new Vector3(x2, 0.52f, z2);

        quad.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1);
    }
}
