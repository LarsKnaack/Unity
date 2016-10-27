using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
    // Use this for initialization
    public GameObject hamburgerPrefab;
    private System.Random rand;
    private float min;
    private float max;
    void Start()
    {
        rand = new System.Random();
        min = -3.0f;
        max = min * -1;

        GenerateHamburgers();
        /*
        foreach (Transform child in transform)
        {
            min = -4.0f;
            max = 4.0f;
            
            Vector3 tmp = child.gameObject.transform.position;
            tmp.x = GetRandomX();
            child.gameObject.transform.position = tmp;
        }*/
    }

    private void GenerateHamburgers()
    {
        for (int i = -44; i < 44; i = i + 2)
        {
            GameObject tmp = (GameObject)Instantiate(hamburgerPrefab);
            Vector3 position = new Vector3(GetRandomX(), 0.75f, (float)i);
            tmp.gameObject.transform.position = position;
            tmp.gameObject.SetActive(true);
        }
    }

    private float GetRandomX()
    {
        return (float)rand.NextDouble() * (max - min) + min;
    }
}
