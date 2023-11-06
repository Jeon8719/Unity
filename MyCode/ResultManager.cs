using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public GameObject scoreText;
    private void Start()
    {
        scoreText.GetComponent<Text>().text = GameManager.totalscore.ToString();
    }
    private void Update()
    {
        
    }
}
