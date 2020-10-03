using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public Material wallNormal;
    public Material wallChanging;
    public Material floorNormal;
    public Material floorChanging;
    public Material ground;
    public Material groundChange;
    public Material final;

    public List<Texture2D> floorTex = new List<Texture2D>();
    public List<Texture2D> floorNormals = new List<Texture2D>();

    public List<GameObject> walls = new List<GameObject>(6);
    public GameObject floor;

    private bool changingTextures = false;
    [SerializeField]
    
    private bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        floorNormal.SetTexture("Texture2D_266AE8AE", floorTex[0]);
        floorNormal.SetTexture("Texture2D_20F4052F", floorNormals[0]);
        floor.GetComponent<MeshRenderer>().material = ground;
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<MeshRenderer>().material = wallNormal;
        }
    }

    public void ChangeRoomCondition()
    {
        if (start)
        {
            floor.GetComponent<MeshRenderer>().material = groundChange;
            foreach (GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = wallChanging;
            }
            changingTextures = true;
            start = false;
            return;
        }

        if (!changingTextures)
        {
            if (EventHandler.events.cycle == 4)
            {
                floor.GetComponent<MeshRenderer>().material = final;
            }

            floorChanging.SetTexture("Texture2D_E95FAD52", floorTex[EventHandler.events.cycle]);
            floorChanging.SetTexture("Texture2D_A2475B51", floorNormals[EventHandler.events.cycle]);
            floorChanging.SetTexture("Texture2D_96F304F0", floorTex[EventHandler.events.cycle + 1]);
            floorChanging.SetTexture("Texture2D_76445688", floorNormals[EventHandler.events.cycle + 1]);
            floorChanging.SetInt("Vector1_20B391B5", EventHandler.events.cycle * 10);
            ChangePerlinCorruption();

            floor.GetComponent<MeshRenderer>().material = floorChanging;
            foreach (GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = wallChanging;
            }
        }

        else
        {
            EventHandler.events.cycle++;
            floorNormal.SetTexture("Texture2D_266AE8AE", floorTex[EventHandler.events.cycle]);
            floorNormal.SetTexture("Texture2D_20F4052F", floorNormals[EventHandler.events.cycle]);
            floorNormal.SetInt("Vector1_F96CC34", EventHandler.events.cycle * 10);

            floor.GetComponent<MeshRenderer>().material = floorNormal;
            foreach (GameObject wall in walls)
            {
                wall.GetComponent<MeshRenderer>().material = wallNormal;
            }
        }

        changingTextures = !changingTextures;
    }

    private void ChangePerlinCorruption()
    {
        switch(EventHandler.events.cycle)
        {
            case 0: floorChanging.SetInt("Vector1_57198B2E", 5); break;
            case 1: floorChanging.SetInt("Vector1_57198B2E", 10); break;
            case 2: floorChanging.SetInt("Vector1_57198B2E", 20); break;
            case 3: floorChanging.SetInt("Vector1_57198B2E", 50); break;
            case 4: floorChanging.SetInt("Vector1_57198B2E", 100); break;
            default: floorChanging.SetInt("Vector1_57198B2E", 100); break;
        }
    }

    [UnityEditor.CustomEditor(typeof(RoomChange))]
    public class UIElementEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            RoomChange uiElement = (RoomChange)target;
            if (GUILayout.Button("Change Room Type"))
            {
                uiElement.ChangeRoomCondition();
            }
        }
    }
}
