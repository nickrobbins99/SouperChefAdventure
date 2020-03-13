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
    public Soup chef;
    // Start is called before the first frame update
    void Start()
    {
        /*
        string path = "Assets/files/Appetites.json";
        StreamReader reader = new StreamReader(path);
        string json_string = reader.ReadToEnd();
        */

        //appetites = JsonUtility.FromJson<List<Appetite>>(json_string);
        appetites = SetupAppetites();
        
        RoundSetup();
    }
    List<Appetite> SetupAppetites()
    {
        List<Appetite> appetiteList = new List<Appetite>();

        Appetite appetite1 = new Appetite();
        appetite1.app_texture = 6;
        appetite1.app_umami = 10;
        appetite1.app_impact = 6;
        appetite1.app_vigor = 25;
        appetite1.app_aroma = 22;
        appetite1.description = "I'm in the mood for a hearty and fragrant soup. Nothing too powerful.";
        appetiteList.Add(appetite1);

        Appetite appetite2 = new Appetite();
        appetite2.app_texture = 5;
        appetite2.app_umami = 5;
        appetite2.app_impact = 25;
        appetite2.app_vigor = 25;
        appetite2.app_aroma = 7;
        appetite2.description = "I'm in the mood for something energizing. Electrifying, you could say.";
        appetiteList.Add(appetite2);

        Appetite appetite3 = new Appetite();
        appetite3.app_texture = 20;
        appetite3.app_umami = 5;
        appetite3.app_impact = 30;
        appetite3.app_vigor = 10;
        appetite3.app_aroma = 5;
        appetite3.description = "I'm in the mood for something with a lot of crunch, like chips, but in a soup.";
        appetiteList.Add(appetite3);

        Appetite appetite4 = new Appetite();
        appetite4.app_texture = 10;
        appetite4.app_umami = 25;
        appetite4.app_impact = 5;
        appetite4.app_vigor = 16;
        appetite4.app_aroma = 14;
        appetite4.description = "I'm in the mood for a savory meal.";
        appetiteList.Add(appetite4);

        Appetite appetite5 = new Appetite();
        appetite5.app_texture = 6;
        appetite5.app_umami = 6;
        appetite5.app_impact = 22;
        appetite5.app_vigor = 14;
        appetite5.app_aroma = 30;
        appetite5.description = "I'm in the mood for something that will make my nose tickle.";
        appetiteList.Add(appetite5);

        Appetite appetite6 = new Appetite();
        appetite6.app_texture = 26;
        appetite6.app_umami = 10;
        appetite6.app_impact = 5;
        appetite6.app_vigor = 20;
        appetite6.app_aroma = 15;
        appetite6.description = "I'm in the mood for something smooth. Keep the crunchy bits to a minimum!";
        appetiteList.Add(appetite6);

        return appetiteList;

    }
    void RoundSetup()
    {
        chef.Reset();
        appetite = appetites[Random.Range(0, appetites.Count)];
        GetComponent<Text>().text = appetite.description;
        timer.StartTimer();
    }
    public void GradeSoup()
    {
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
