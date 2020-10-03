using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public static FadeOut fadeOut;

    private void Awake()
    {
        fadeOut = this;
    }

    private Material mat;
    public bool started = false;
    private bool faded = false;
    private RoomChange room;
    private GameObject player;
    private bool changeRoom;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.color = new Color(0, 0, 0, 0);
        player = GameObject.FindGameObjectWithTag("Player");
        room = FindObjectOfType<RoomChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (!faded)
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + Time.deltaTime);
                if (mat.color.a >= 1)
                {
                    faded = true;
                    player.transform.position = playerPos;
                    if (changeRoom)
                    {
                        changeRoom = false;
                        room.ChangeRoomCondition();
                    }
                }
            }
            else
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - Time.deltaTime);
                started = faded = mat.color.a > 0;
            }
        }
    }

    public void StartFadeOut(Vector3 nextPos, bool finalChange)
    {
        started = true;
        playerPos = nextPos;
        
        if (finalChange)
        {
            mat.color = new Color(1, 1, 1, 0);
        }
    }
}
