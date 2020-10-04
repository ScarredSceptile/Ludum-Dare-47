using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    [SerializeField]
    public GameObject credit;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        credit.transform.position = new Vector3(credit.transform.position.x, credit.transform.position.y + Time.deltaTime * speed, credit.transform.position.z);

        if (credit.transform.position.y >= 620)
        {
            Application.Quit();
        }
    }
}
