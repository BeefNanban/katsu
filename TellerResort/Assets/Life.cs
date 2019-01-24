using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    public int playerlife;
    public int numLife;

    public Image[] hearts;
    public Sprite fullLife;
    public Sprite emptyLife;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < hearts.Length; i++)
        {
            if(i < numLife)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            
        }
	}
}
