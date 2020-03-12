using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AppetitePicker : MonoBehaviour
{
    struct Appetite
    {
        public float app_texture { get; set; }
        public float app_umami { get; set; }
        public float app_impact { get; set; }
        public float app_vigor { get; set; }
        public float app_aroma { get; set; }

        public string description { get; set; }
    }
    Appetite appetite;
    List<Appetite> appetites;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/files/Appetites.json";
        StreamReader reader = new StreamReader(path);
        string json_string = reader.ReadToEnd();

        appetites = JsonUtility.FromJson<List<Appetite>>(json_string);
        RoundSetup();
    }
    void RoundSetup()
    {
        appetite = appetites[Random.Range(0, appetites.Count)];
        GetComponent<Text>().text = "The Lord's Appetite: " + appetite.description;
        timer.StartTimer();
    }
    public void GradeSoup()
    {
        Soup chef = GameObject.Find("chef").GetComponent<Soup>();
        float chef_texture = chef.texture;
        float chef_umami = chef.umami;
        float chef_impact = chef.impact;
        float chef_vigor = chef.vigor;
        float chef_aroma = chef.aroma;

        if(chef_texture >= appetite.app_texture && chef_umami >= appetite.app_umami && chef_impact >= appetite.app_impact && chef_vigor >= appetite.app_texture && chef_aroma >= appetite.app_aroma)
        {
            GetComponent<Text>().text = "The Lord is Satisfied";
            //win first round, begin new round
            Invoke("RoundSetup", 5f);
        }
        else
        {
            GetComponent<Text>().text = "The Lord is Unsatisfied";
            //lose round, begin new round
            Invoke("RoundSetup", 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
