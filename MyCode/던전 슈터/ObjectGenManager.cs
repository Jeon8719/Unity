using UnityEngine;

public class ObjectGenManager : MonoBehaviour
{
    ObjectGenPoint[] objectGenPoints;

    // Start is called before the first frame update
    void Start()
    {
        objectGenPoints = FindObjectsOfType<ObjectGenPoint>();

    }

    // Update is called once per frame
    void Update()
    {
        ItemData[] items = GameObject.FindObjectsOfType<ItemData>();
        for (int i = 0; i < items.Length; i++)
        {
            ItemData item = items[i];
            if (item.type == ItemType.arrow)
                return;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (ItemKeeper.hasArrows == 0 && player != null)
        {
            int idx = Random.Range(0, objectGenPoints.Length);
            ObjectGenPoint objectGen = objectGenPoints[idx];
            objectGen.ObjectCreate();


        }
    }
}
