using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemDBMS : MonoBehaviour
{   
    public item item01; //�����ۿ� ���� ����
    public item item02; //�����ۿ� ���� ����
    public item item03; //�����ۿ� ���� ����

    int item_index = 0; //�����ۿ� ���� ����;

    public Image item_icon; //public Image item_icon; //������ �����ܿ� ���� ����
    public Text[] textUI; //�ؽ�Ʈ�� ���� �迭
    
    public GameObject Panel; //DBMS �г�
    public bool isOpen = true;//DBMS â�� �������� Ȯ��

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
                        textUI[5].text = "����";
                        break;
                    case ITEM_TYPE.AMMOR:
                        textUI[5].text = "����";
                        break;
                    case ITEM_TYPE.QUEST:
                        textUI[5].text = "��Ÿ";
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
                //enum�� ���¿� ���� �ؽ�Ʈ�� ������ ó���մϴ�.
                switch (item02.item_type)
                {
                    case ITEM_TYPE.WEAPON:
                        textUI[5].text = "����";
                        break;
                    case ITEM_TYPE.AMMOR:
                        textUI[5].text = "����";
                        break;
                    case ITEM_TYPE.QUEST:
                        textUI[5].text = "��Ÿ";
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
                //enum�� ���¿� ���� �ؽ�Ʈ�� ������ ó���մϴ�.
                switch (item03.item_type)
                {
                    case ITEM_TYPE.WEAPON:
                        textUI[5].text = "����";
                        break;
                    case ITEM_TYPE.AMMOR:
                        textUI[5].text = "����";
                        break;
                    case ITEM_TYPE.QUEST:
                        textUI[5].text = "��Ÿ";
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
                textUI[5].text = "����";
                break;
            case ITEM_TYPE.AMMOR:
                textUI[5].text = "����";
                break;
            case ITEM_TYPE.QUEST:
                textUI[5].text = "��Ÿ";
                break;

        }
        textUI[6].text = item01.item_speed.ToString();


        /*UI �������� �ϳ��� ���� ������� �۾� ����. (UI ������ŭ)
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
