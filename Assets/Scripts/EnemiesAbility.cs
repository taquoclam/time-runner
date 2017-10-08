using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAbility : MonoBehaviour
{
    public string[] abilities; // Enemy's ability
    // note: general rule of adding enemy's ability
    // each string will contain this specific syntax: [power]:[attribute]
    // [power] could be: "s" : shoot, "x": splasher, "j": jumper, "b": boomer
    // [attribute] could be: name of attribute + the number of that attribute (true/false set as 1/0). 
    //and each attribute can be seperated by ",".
    // for instance: abilities = ["s:speed+100,spread+100", "x:speed+200,height+100"]

    private Rigidbody2D body;
    private bool[] setAbi;
    private string evilType; // name of Enemy 

    // Use this for initialization
    void Start()
    {
        evilType = name.ToLower();
        body = GetComponent<Rigidbody2D>();

        for (int i = 0; i < abilities.Length; i++)
        {
            if (!abilities[i].Equals(""))
            {
                string power = abilities[i].Split(':')[0];
                string[] attributes = abilities[i].Split(':')[1].Split(',');

                if (power.Equals("j")) // power is jumper
                {
                    print("hello");
                    for (int y = 0; y < attributes.Length; y++) // run each attribute 
                                                                // todo: work in progress.
                    {
                        string[] attribute = attributes[i].Split('+');
                        int height = 6; // default setting for jumper
                        int speed = 10;
                        int followed_player = 0;

                        if (attribute[0].Equals("height"))
                        {
                            int.TryParse(attribute[1], out height);
                        }
                        if (attribute[0].Equals("speed"))
                        {
                            int.TryParse(attribute[1], out speed);
                        }
                        if (attribute[0].Equals("followed_player"))
                        {
                            int.TryParse(attribute[1], out followed_player);
                        }
                        if (followed_player == 0 || followed_player == 1 && Input.GetButtonDown("Jump"))
                        {
                            body.velocity = new Vector2(0, GameControl.instance.scrollSpeed * height * speed);
                        }
                    }

                }
                if (power.Equals("b")) // power is boomer
                {
                    for (int y = 0; y < attributes.Length; y++) // run each attribute 
                                                                // todo: work in progress.
                    {
                        string[] attribute = attributes[i].Split('+');
                        int spread = 6; // default setting for boomer
                        int radius = 10;
                        int followed_player = 0;

                        if (attribute[0].Equals("spread"))
                        {
                            int.TryParse(attribute[1], out spread);
                        }
                        if (attribute[0].Equals("radius"))
                        {
                            int.TryParse(attribute[1], out radius);
                        }
                        if (attribute[0].Equals("followed_player"))
                        {
                            int.TryParse(attribute[1], out followed_player);
                        }
                        if (followed_player == 0 || followed_player == 1 && Input.GetButtonDown("Jump"))
                        {
                            ;
                        }
                    }

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}