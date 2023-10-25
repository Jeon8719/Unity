using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemDBMS : MonoBehaviour
{   
    public item item01; //아이템에 대한 변수
    public item item02; //아이템에 대한 변수
    public item item03; //아이템에 대한 변수

    int item_index = 0; //아이템에 대한 접근;

    public Image item_icon; //public Image item_icon; //아이템 아이콘에 대한 정보
    public Text[] textUI; //텍스트에 대한 배열
    
    public GameObject Panel; //DBMS 패널
    public bool isOpen = true;//DBMS 창이 켜졌는지 확인

    // Start is called before the first frame update
    void Start()
    {
        Default();
    }
        void Update ()
        {
            if (Input.GetKeyDown(KeyCode.I)) 
            {
                Onoff();
                Panel.SetActive(isOpen);
            }
        }


        public void Onoff()
        {
            isOpen = !isOpen;
        }
    public void SetItemData(int index)
    {
        switch (index)
        {
            case 0:
                item_icon.sprite = item01.item_icon;
                textUI[0].text = item01.item_name;
                textUI[1].text = item01.item_description;
                textUI[2].text = item01.item_atk.ToString();
                textUI[3].text = $"{item01.item_def}";
                textUI[4].text = item01.item_attribute.ToString();
                switch (item01.item_type)
                {
                    case ITEM_TYPE.WEAPON:
                        textUI[5].text = "무기";
                        break;
                    case ITEM_TYPE.AMMOR:
                        textUI[5].text = "갑옷";
                        break;
                    case ITEM_TYPE.QUEST:
                        textUI[5].text = "기타";
                        break;

                }
                textUI[6].text = item01.item_speed.ToString();
                break;
            case 1:
                item_icon.sprite = item02.item_icon;

                textUI[0].text = item02.item_name;
                textUI[1].text = item02.item_description;
                textUI[2].text = item02.item_atk.ToString();
                textUI[3].text = $"{item02.item_def}";
                textUI[4].text = item02.item_attribute.ToString();
                //enum의 형태에 따라 텍스트를 별도로 처리합니다.
                switch (item02.item_type)
                {
                    case ITEM_TYPE.WEAPON:
                        textUI[5].text = "무기";
                        break;
                    case ITEM_TYPE.AMMOR:
                        textUI[5].text = "갑옷";
                        break;
                    case ITEM_TYPE.QUEST:
                        textUI[5].text = "기타";
                        break;
                }
                textUI[6].text = item02.item_speed.ToString();
                break;
            case 2:
                item_icon.sprite = item03.item_icon;

                textUI[0].text = item03.item_name;
                textUI[1].text = item03.item_description;
                textUI[2].text = item03.item_atk.ToString();
                textUI[3].text = $"{item03.item_def}";
                textUI[4].text = item03.item_attribute.ToString();
                //enum의 형태에 따라 텍스트를 별도로 처리합니다.
                switch (item03.item_type)
                {
                    case ITEM_TYPE.WEAPON:
                        textUI[5].text = "무기";
                        break;
                    case ITEM_TYPE.AMMOR:
                        textUI[5].text = "갑옷";
                        break;
                    case ITEM_TYPE.QUEST:
                        textUI[5].text = "기타";
                        break;
                }
                textUI[6].text = item03.item_speed.ToString();
                break;
                default: break;
        }
    }
    public void Up()
    {
        if (item_index == 2)
        {
            return;
        }
        item_index++;
        SetItemData(item_index);
    }
    public void Default()
    {
        item_index = 0;
        item_icon.sprite = item01.item_icon;
        textUI[0].text = item01.item_name;
        textUI[1].text = item01.item_description;
        textUI[2].text = item01.item_atk.ToString();
        textUI[3].text = $"{item01.item_def}";
        textUI[4].text = item01.item_attribute.ToString();
        switch (item01.item_type)
        {
            case ITEM_TYPE.WEAPON:
                textUI[5].text = "무기";
                break;
            case ITEM_TYPE.AMMOR:
                textUI[5].text = "갑옷";
                break;
            case ITEM_TYPE.QUEST:
                textUI[5].text = "기타";
                break;

        }
        textUI[6].text = item01.item_speed.ToString();


        /*UI 묶음에서 하나의 값을 대상으로 작업 진행. (UI 개수만큼)
        foreach (var item in textUI)
        {
            
        }
        */
    }
    public void Down() 
    {
        if (item_index ==0 )
        {
            return;
        }
        item_index--;
        SetItemData(item_index);
    }
    public void Randomindex()
    {
        int randomx = Random.Range(0, 3);
        item_index = randomx;
        SetItemData(randomx);
    }
    // Update is called once per frame

}
