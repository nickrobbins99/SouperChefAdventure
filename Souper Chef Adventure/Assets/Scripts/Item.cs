using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string item_name;
    //qualities
    //[Range(-5.0f,5.0f)]
    public float texture;
    //[Range(-5.0f, 5.0f)]
    public float umami;
    //[Range(-5.0f, 5.0f)]
    public float impact;
    //[Range(-5.0f, 5.0f)]
    public float vigor;
    //[Range(-5.0f, 5.0f)]
    public float aroma;

    public float despawnTime;

    // Start is called before the first frame update
    public void Start()
    {
        //item despawn
        despawnTime = Random.Range(30f, 50f);
        Invoke("Despawn", despawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Despawn()
    {
        gameObject.transform.parent.gameObject.GetComponent<ItemSpawner>().totalItemsSpawned -= 1;
        Destroy(this.gameObject);
    }
}
