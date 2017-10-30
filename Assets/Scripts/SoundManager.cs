using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	public AudioSource levelOneEnemyDeath;
    public AudioSource CheckSound;
    public Slider volume;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void levelOneDied(){
		levelOneEnemyDeath.Play ();
	}

    // Set volume for sound 
    public void SetLevel()
    {
        AudioListener.volume = volume.value;
    }

    public void checkSound()
    {
        CheckSound.Play();
    }
}
