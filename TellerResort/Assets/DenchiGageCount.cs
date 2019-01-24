using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DenchiGageCount : MonoBehaviour {

    private float timeleft;
    public bool startFlag = false;
    Slider denchiSlider;
    float denchi = 1;
    //public GameObject gameObject;


    // Use this for initialization
    void Start () {
        denchiSlider = GameObject.Find("Denchigage").GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (startFlag)
        {
            timeleft -= Time.deltaTime;
            if(timeleft <= 1.0)
            {
                timeleft = 1.0f;
                denchi -= 0.0005f;

                if(denchi > 1)
                {
                    denchi = 0;
                }
                denchiSlider.value = denchi;
            }
        }
	}
}
