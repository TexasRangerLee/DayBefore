using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyFiller : MonoBehaviour
{
    //set up energy wheel references, mostly handled via unity inspector
    public GameObject eObj;
    public Image eImage;

    //set up health wheel references, mostly handled via unity inspector
    public GameObject hObj;
    public Image hImage;

    //set up health/energy value references
    public GameObject pacman;
    public float energy;
    public float health;

    //make reference to pacman's fsm
    public Pac_Man_FSM script;

    //set up megachomp counter
    [SerializeField]
    private Text megaChompCounter;

    void Start()
    {
        //initialize starting health/energy
        script = pacman.GetComponent<Pac_Man_FSM>();
    }

    void Update()
    {
        //change energy
        energy = script.energy;
        EnergyChange(energy);

        //change health
        health = script.currentHealth;
        HealthChange(health);

        ChompCounterChange(energy);
    }

    void EnergyChange(float value)
    {
        //if energy>megachomp value, set to max
        //else if energy<0, set to min
        //else energy/100 to get true float value for use with image fill; fill wheel appropriately
        if (value >= 100)
        {
            value = 1;
        }
        else if (value <= 0)
        {
            value = 0;
        }
        else
        {
            value /= 100;
        }
        eImage.fillAmount = value;
    }

    void HealthChange(float value)
    {
        //see energy, may need change
        if (value >= 100)
        {
            value = 1;
        }
        else if (value <= 0)
        {
            value = 0;
        }
        else
        {
            value /= 100;
        }
        hImage.fillAmount = value;
    }

    void ChompCounterChange(float energy)
    {
        //convert energy to an int because that's easier
        int energy2 = (int)energy;
        energy2 /= 100;
        megaChompCounter.text = "x" + energy2;
    }
}
