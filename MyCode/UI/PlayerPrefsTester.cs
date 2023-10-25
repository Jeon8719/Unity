using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTester : MonoBehaviour
{
    /*PlyaerPrefs
     * ����Ƽ ���ο� ������ �����͸� ���� �� �ε��ϴ� �뵵�� ������� ������
     * ������ ����, ���� ���� ���� �����ϴ� �뵵�� ���
     * 
     * Ư¡)float, string ,int �����͸� ����
     * ���� ��� PlayerPrefs.SetFloat,SetInt,SetString("Ű �̸�". ��);
     * �α� ��� PlayerPrefs.GetFloat,GetInt,GetString("Ű �̸�");
     * �ش� Ű ���� ���� üũ PlayerPrefs.HasKey("Ű �̸�") 
     * 
     * Ű ���� PlayerPrefs.DeleteKey("Ű")
     *         PlayerPrefs.DeleteAll()
     * 
     * �� ���¸� �����մϴ�.
     * PlayerPrefs.Save()
     * 
     */
    public string id = "SK0714";
    public int pw = 1234;

    private void Start()
    {
        PlayerPrefs.SetString("ID", "SK0714"); //���ڿ� ���
        PlayerPrefs.SetInt("PASS", 1234);
        Register();
    }
    public void Register()
    {
        if(id.Equals(PlayerPrefs.GetString("ID")))
        {
            if(pw == PlayerPrefs.GetInt("PASS"))
            {
                Debug.Log("�α��� ����!");
            }
            else
            {
                Debug.Log("��й�ȣ�� Ʋ�Ƚ��ϴ�!");
            }
        }
        else
        {
            Debug.Log("���̵� Ʋ�Ƚ��ϴ�!");
        }
    }
}
