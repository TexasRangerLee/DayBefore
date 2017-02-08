using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderInitScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //This sets the audio slider's value to the listener's level, so changes made are "saved" upon
        //exiting and reentering the options screen
        this.GetComponent<Slider>().value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

