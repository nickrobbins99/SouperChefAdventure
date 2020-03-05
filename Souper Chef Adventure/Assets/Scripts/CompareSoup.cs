using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CompareSoup : MonoBehaviour
{
    struct appetite
    {
        float app_texture;
        float app_umami;
        float app_impact;
        float app_vigor;
        float app_aroma;

        string description;
    }

    List<appetite> appetites;

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/files/Appetites.json";
        StreamReader reader = new StreamReader(path);
        string json_string = reader.ReadToEnd();

        appetites = JsonUtility.FromJson<List<appetite>>(json_string);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GradeSoup()
    {
        Soup chef = GameObject.Find("chef").GetComponent<Soup>();
        float chef_texture = chef.texture;
        float chef_umami = chef.umami;
        float chef_impact = chef.impact;
        float chef_vigor = chef.vigor;
        float chef_aroma = chef.aroma;
    }
}
