using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyFiller : MonoBehaviour
{

    public GameObject obj;
    public Image image;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    void EnergySet(float value)
    {
        //if value is sent in out of 100, convert it to decimal
        //otherwise, it's sent in as either 0 (empty), 1 (full), or
        //a decimal that's already out of 100, so there's no need to change it
        if (value > 1)
        {
            value /= 100;
        }
        image.fillAmount = value;
    }

    void EnergyChange(float value)
    {
        //same as above, but if a negative value is sent (meaning health loss)
        //that is also accounted for
        if (value > 1 || value < -1)
        {
            value /= 100;
        }

        //if fillamount would be set below minimum 0, set to minimum 0
        if (image.fillAmount - value < 0)
        {
            image.fillAmount = 0;
        }
        //otherwise, if it would be set above maximum 1, set to maximum 1
        else if (image.fillAmount + value > 1)
        {
            image.fillAmount = 1;
        }
        //otherwise, it is set somewhere between 0 & 1, so just set it normally
        else
        {
            image.fillAmount += value;
        }
    }


}
