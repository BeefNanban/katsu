using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVitality : MonoBehaviour {

    public GameObject lifeheart;
    public float life = 4;
    public float lifemax = 4;

    public GameObject Flashlight;
    public GameObject denchiGage;
    public float denchi = 100;
    public float denchiMax = 100;
    public float removeBatteryValue = 0.05f;
    public float secondBatteryValue = 5f;

    public GameObject staminaSlider;
    public float stamina = 100;
    public float staminaMax = 100;
    public float staminaValue = 5;
    public float secondsutamina = 10;

    public bool paused;

	// Use this for initialization
	void Start () {
        stamina = staminaMax;
        denchi = denchiMax;

        staminaSlider.GetComponent<Slider>().maxValue = staminaMax;
        staminaSlider.GetComponent<Slider>().value = staminaMax;

        denchiGage.GetComponent<Slider>().maxValue = denchiMax;
        denchiGage.GetComponent<Slider>().value = denchiMax;
	}
	
	// Update is called once per frame
	void Update () {
        staminaSlider.GetComponent<Slider>().value = stamina;
        denchiGage.GetComponent<Slider>().value = denchi;

        if(stamina / staminaMax*100 <= 0)
        {
            stamina = 0.00f;
        }

        if (denchi / denchiMax * 100 <= 0)
        {
            denchi = 0.00f;
            Flashlight.transform.Find("Spotlight").gameObject.GetComponent<Light>().intensity = 0.0f;
        }
	}

    public IEnumerator RemoveDenchi(float value,float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            if(denchi > 0)
            {
                denchi -= value;
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        // remove noise sound
        if (collider.gameObject.transform.tag == "Enemy")
        {
            if (life > 0 && paused == false)
            {
                this.GetComponent<AudioSource>().clip = null;
                this.GetComponent<AudioSource>().loop = false;
            }
        }
    }
}
