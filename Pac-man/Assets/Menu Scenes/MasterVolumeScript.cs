using UnityEngine;
using System.Collections;

public class MasterVolumeScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Used with the master volume slider
    public void MasterVolumeChange(UnityEngine.UI.Slider slider)
    { AudioListener.volume = slider.value; }
}
