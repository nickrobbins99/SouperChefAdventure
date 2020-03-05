using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soup : MonoBehaviour
{
    public List<string> itemList;

    //Soup qualities
    public float texture;
    public float umami;
    public float impact;
    public float vigor;
    public float aroma;

    // Start is called before the first frame update
    void Start()
    {
        itemList = new List<string>();
        texture = 0;
        umami = 0;
        impact = 0;
        vigor = 0;
        aroma = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void addItem(Item itemToAdd)
    {
        itemList.Add(itemToAdd.item_name);
        texture += itemToAdd.texture;
        umami += itemToAdd.umami;
        impact += itemToAdd.impact;
        vigor += itemToAdd.vigor;
        aroma += itemToAdd.aroma;
    }
}
