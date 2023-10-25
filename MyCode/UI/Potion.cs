using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public Button potion_button; //������ ���޿� ��ư
    public Image potion_Image; //���� �̹��� filled Ÿ��
    public Text potion_cooltext; //���� �� TEXT
    public Text potion_text; //���� ���� TEXT
    public int potion_count; //���� ���� ������
    public int hp; //���� ȸ����
    public float cool_time = 3.0f; //��
    public float time_check = 3.0f; //�ð�üũ


    // Start is called before the first frame update
    void Start()
    {
        potion_count = int.Parse(potion_text.text);
        //�ؽ�Ʈ�� ���� ���� ������ ����
        potion_button.onClick.AddListener(OnPotionButtonEnter);
        //���� ��ư�� OnPotionButtonEnter �Լ� ����
    }
    public void OnPotionButtonEnter()
    {
        StartCoroutine(UsePotion());
        //�ڷ�ƾ UsePotion ����
    }

    private IEnumerator UsePotion()
    {
        Debug.Log($"ü�� {50} ȸ��");
        potion_count--;//���� ����
        potion_text.text = potion_count.ToString();//���� ī��Ʈ ����
        potion_button.enabled = false;

        while(time_check > 0.0f)//��Ÿ�Ӹ�ŭ �ݺ�
        {
            time_check -= Time.deltaTime; //Ÿ��üũ
            potion_Image.fillAmount = time_check / cool_time;//Ÿ��üũ/��ü�ð��� ��ġ��ŭ �̹�ġ ä���

            string time = TimeSpan.FromSeconds(time_check).ToString("s\\:ff");
            //���� �ð� üũ�� �а� ���� ���·� ǥ��
            //�а� �ʸ� �и�
            string[] t = time.Split(":");
            potion_cooltext.text = $"{t[0]} : {t[1]}";
            yield return new WaitForFixedUpdate();

        }
        //while Ż�� �� ����
        potion_button.enabled = true;
        potion_Image.fillAmount = 1;
        potion_cooltext.text = "";
        time_check = cool_time;
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
