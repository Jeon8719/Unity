using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenPoint : MonoBehaviour
{
    public GameObject objPrefab;

    public void ObjectCreate()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, -1.0f); 
        Instantiate(objPrefab, position, Quaternion.identity);


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
