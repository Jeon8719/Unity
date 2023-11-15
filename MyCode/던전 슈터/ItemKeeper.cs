using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKeeper : MonoBehaviour
{
    public static int hasKeys = 0;          //열쇠 수
    public static int hasArrows = 0;        //화살 소지수
    public static int level = 1;
    public static int exp = 0;
    public static int Maxexp = 5;
    // Start is called before the first frame update
    void Start()
    {
        //아이템 불러오기
        hasKeys = PlayerPrefs.GetInt("Keys");
        hasArrows = PlayerPrefs.GetInt("Arrows");
        level = PlayerPrefs.GetInt("levels");
        exp = PlayerPrefs.GetInt("exps");
        Maxexp = PlayerPrefs.GetInt("Maxexps");
    }


    //아이템 저장하기
    public static void SaveItem()
    {
        PlayerPrefs.SetInt("Keys", hasKeys);
        PlayerPrefs.SetInt("Arrows", hasArrows);
        PlayerPrefs.SetInt("levels", level);
        PlayerPrefs.SetInt("exps", exp);
        PlayerPrefs.SetInt("Maxexps", Maxexp);
    }
}
