using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {
    public BossController boss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BossController boss = FindObjectOfType<BossController>();
        if(boss != null)
            gameObject.GetComponent<Text>().text = boss.life.ToString();
	}
}
