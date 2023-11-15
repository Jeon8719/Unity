using UnityEngine;
public enum ExitDirection { right, left, up, down }


public class Exit : MonoBehaviour
{
    public string sceneName = "";
    public int doorNumber = 0;
    public ExitDirection direction = ExitDirection.down;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (doorNumber == 100)
            {
                //BGM ����
                //SoundManager.soundManager.StopBgm();
                //SE ��� (���� Ŭ����)
                //SoundManager.soundManager.SEPlay(SEType.GameClear);
                //���� Ŭ����
                GameObject.FindObjectOfType<UIManager>().GameClear();
            }
            else
            {
                string nowScene = PlayerPrefs.GetString("LastScene");
                SaveDataManager.SaveArrangeData(nowScene); // ��ġ������ ����
                RoomManager.ChangeScene(sceneName, doorNumber);
            }
        }
    }
}