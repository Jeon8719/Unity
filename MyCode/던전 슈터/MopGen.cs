using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MopGen : MonoBehaviour
{
    ObjectGenPoint[] objectGenPoints;
    float time;
    public int Gentime;
    int Gen;
    public int MaxGen;
    // Start is called before the first frame update
    void Start()
    {
        objectGenPoints = FindObjectsOfType<ObjectGenPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectGenPoints == null)
        {
            Destroy(gameObject);
        }
        else if(Gen >= MaxGen)
        {
            time = 0;
        }
        else if (time > Gentime)
        {
            int idx = Random.Range(0, objectGenPoints.Length);
            ObjectGenPoint objectGen = objectGenPoints[idx];
            objectGen.ObjectCreate();
            Gen++;
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
