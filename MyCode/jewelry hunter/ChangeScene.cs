using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string RestartN;
    public string NextN;

    public void Restart()
    {
        
        SceneManager.LoadScene(RestartN);

    }

    public void Next()
    {
        SceneManager.LoadScene(NextN);
    }



}
