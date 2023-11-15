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
                //BGM 정지
                //SoundManager.soundManager.StopBgm();
                //SE 재생 (게임 클리어)
                //SoundManager.soundManager.SEPlay(SEType.GameClear);
                //게임 클리어
                GameObject.FindObjectOfType<UIManager>().GameClear();
            }
            else
            {
                string nowScene = PlayerPrefs.GetString("LastScene");
                SaveDataManager.SaveArrangeData(nowScene); // 배치데이터 저장
                RoomManager.ChangeScene(sceneName, doorNumber);
            }
        }
    }
}