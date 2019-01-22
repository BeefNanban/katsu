using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO;
    private bool isOn = false;

    // Use this for initialization
    void Start()
    {
        lightGO.SetActive(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        //toggle flashlight on key down
        if (Input.GetKeyDown(KeyCode.X))
        {
            isOn = !isOn;
            
            if (isOn)
            {
                lightGO.SetActive(true);
            }
            else
            {
                lightGO.SetActive(false);

            }
        }
    }
}
