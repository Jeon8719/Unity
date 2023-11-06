using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : MonoBehaviour
{
    private Phoenix instance = null;
    private int check = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance == null)
        {
            Destroy(gameObject);
        }

        check++;
        Debug.Log("Phoenix check = " + check);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
