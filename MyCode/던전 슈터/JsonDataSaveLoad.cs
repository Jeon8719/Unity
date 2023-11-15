using System.IO;
using UnityEngine;
[System.Serializable]
public class WeaponData
{
    public string Name;
    public int Rank;
    public int Attack;
    public int STR;
    public int DEX;
    public int INT;
    public int LUK;
}
public class JsonDataSaveLoad : MonoBehaviour
{
    string fileName;
    string path;
    private void Start()
    {
     
        Save();
        Load();
    }
    // Start is called before the first frame update
    public void Save()
    {
        WeaponData weaponData = new WeaponData()
        {
            Name = "Sword",
            Rank = 0,
            Attack = 1,
            STR = 2,
            DEX = 3,
            INT = 4,
            LUK = 5
        };
        string json = JsonUtility.ToJson(weaponData);
        Debug.Log(json);
        fileName = weaponData.Name;
        path = Application.dataPath + "/Datas/" + fileName + ".json";
        //Application.dataPath : 프로젝트 내부 경로 (Asset)
        //읽기 전용) 런타임 중 수정 & 작성 불가
        File.WriteAllText(path, json);
    }
    public void Load()
    {
       string json = File.ReadAllText(path);
        WeaponData weaponData = JsonUtility.FromJson<WeaponData>(json);
        Debug.Log("데이터 로드 성공");
        Debug.Log(weaponData.Name);
        Debug.Log(weaponData.Attack);
        Debug.Log(weaponData.STR);
        Debug.Log(weaponData.DEX);
        Debug.Log(weaponData.INT);
        Debug.Log(weaponData.LUK);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
