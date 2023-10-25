using UnityEngine;


//2023-10-17 ManagerSystem Ʋ �߰�
//2023-10-23 ManagerSystem�� ���ҽ��� �ε��ϴ� ��� �߰�

/// <summary>
/// �Ŵ������� �����ϴ� �ý��� �ڵ�
/// </summary>
public class ManagerSystem : MonoBehaviour
{
    //�ܺο��� ���� �Ұ����� �Ŵ����ý��� ������ ��ü
    private static ManagerSystem sound_instance;
    //����Ŵ���
    SoundManager sound_manager = new SoundManager();
    public static SoundManager SM { get { return Instance.sound_manager; } }


    //1. �Ŵ����� ���� ������Ƽ�� ����.
    //������Ƽ�� Ŭ������ ������ �ִ� ���� ���� ���� �Ӽ�
    //�� ������Ƽ�� �Ŵ��� �ý��ۿ� ���� ������Ƽ
    static ManagerSystem Instance
    {
        get
        {
            Init();
            return sound_instance;
        }

        //������Ƽ���� ���� �����ϴ� get�� ���� �����ϴ� set�� ����
        //�Ŵ��� �ý��ۿ� ���� ������ ���� ���⿡ �� �ڵ忡�� set�� ����

    }
    /// <summary>
    /// �Ŵ��� �ý����� ����Ϸ��� �� ��, ȣ��� �Լ�
    /// </summary>
    static void Init()
    {
        if (sound_instance == null)
        {
            GameObject go = GameObject.Find("Manager System");
            //������Ʈ�� ������ ����
            if (go == null)
            {
                go = new GameObject { name = "Manager System" };
                go.AddComponent<ManagerSystem>();
            }
            //�ı����� �ʵ��� ó��
            DontDestroyOnLoad(go);
            //���� ��ü�� ������� go�κ��� �Ŵ��� �ý����� ����� ����
            sound_instance = go.GetComponent<ManagerSystem>();
            //���� ��ü���� soundmanager�� ���� SoundManager.cs���� ���� Init()ȣ��
            sound_instance.sound_manager.lnit();


        }
    }
}
