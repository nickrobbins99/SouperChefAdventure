using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int totalItemsSpawned;
    public int maxItems;
    public int startItems;
    public List<GameObject> itemList;
    public float spawnFrequency;

    //borders
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        totalItemsSpawned = 0;
        for(int i = 0; i < startItems; i++)
        {
            SpawnItem();
        }
        InvokeRepeating("SpawnItem", spawnFrequency, spawnFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnItem()
    {
        if (totalItemsSpawned < maxItems)
        {
            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);
            GameObject item = Instantiate(itemList[Random.Range(0, itemList.Count)], this.gameObject.transform);
            item.transform.position = new Vector3(x, y, -1f);
            totalItemsSpawned += 1;
        }
    }
}
