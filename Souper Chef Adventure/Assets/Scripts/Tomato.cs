using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tomato : Item
{

    // Start is called before the first frame update
    new void Start()
    {
        item_name = "Tomato";

        texture = 2f;
        umami = 2f;
        impact = 3f;
        vigor = 4f;
        aroma = 2f;

        base.Start();
    }
}
