using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//SO MUCH OF THIS IS RIPPED FROM AN OLD PROJECT I CAN'T EVEN PRETEND TO LIE

public class ButtonActionScript : MonoBehaviour
{
    //Initialize an array of gameobjects for the normal pause menu items
    public GameObject[] pauseObjects;

    //Initialize an array of gameobjects for the confirmation pause menu items
    //currently dummied out
    //public GameObject[] hiddenPauseObjects;

    void Start()
    {
        //On start, find all gameobjects tagged as part of the pause screen
        //GUYS  you'll need this tag to make the pause screen appear when called
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");

        //On start, find all gameobjects tagged as confirmation parts of the pause screen
        //currently dummied out
        //hiddenPauseObjects = GameObject.FindGameObjectsWithTag("PauseHidden");
    }

    //Used with the main menu>play button; goes to the main level
    public void PlayButton()
    {
        //this.GetComponent<AudioSource>().Play(); HELPME (dummied out, we don't have this yet)
        StartCoroutine(DelaySceneLoad("testLevel2"));  //HELPME (we need to get the proper scene name here)
    }

    //Used with the main menu>options button; goes to the options menu
    public void OptionsButton()
    {
        //this.GetComponent<AudioSource>().Play(); HELPME
        StartCoroutine(DelaySceneLoad("Options Menu"));
    }

    //Used with the main menu>quit button; exits the application
    public void QuitButton()
    {
        //this.GetComponent<AudioSource>().Play(); HELPME
        Application.Quit();
    }

    //Used with the pause>resume button
    public void ResumeButton()
    {
        //this.GetComponent<AudioSource>().Play(); HELPME
        //AudioManager BGM = FindObjectOfType<AudioManager>();  HELPME
        //BGM.Pause();
        //Hide all confirmation pause menu object
        //this is currently dummied out
        /*
        foreach (GameObject g in hiddenPauseObjects)
        { g.SetActive(false); }
        */

        //Hide all normal pause menu objects
        //GUYS  this is the unpause function; notice that it sets timescale to 1, in case we do a game clock or something
        //foreach (GameObject g in pauseObjects)
        //{ 
        //    g.SetActive(false);
        //    Debug.Log("ALL THE THINGS ARE GONE!!!");
        //}

        foreach (GameObject go in pauseObjects)
        {
            go.SetActive(false);
        }

        //Set timescale back to 1 to resume game
        Time.timeScale = 1;
        //BGM.ResumeTrack(); HELPME
        Debug.Log("AFTER THE THING!!!");
    }

    //Used with options>back button (currently also with pause>main menu)
    public void MainMenuButton()
    {
        //this.GetComponent<AudioSource>().Play();
        //AudioManager BGM = FindObjectOfType<AudioManager>(); HELPME
        //BGM.toTheMenue(); HELPME
        StartCoroutine(DelaySceneLoad("Main Menu"));
    }

    public void OptionsToMainMenu()
    {
        //this.GetComponent<AudioSource>().Play();
        //AudioManager BGM = FindObjectOfType<AudioManager>();
        //BGM.toTheMenue();
        StartCoroutine(DelaySceneLoad("Main Menu"));
    }

    //Used with the pause>main menu>yes button (currently dummied out)
    public void PauseSureButton()
    {
        //this.GetComponent<AudioSource>().Play(); HELPME
        //AudioManager BGM = FindObjectOfType<AudioManager>();
        //BGM.PauseTrack();
        //If the player quits to main menu, hide the confirmation pause objects
        //currently dummied out
        /*
        foreach (GameObject g in hiddenPauseObjects)
        { g.SetActive(false); }
        */

        //Then hide the normal pause objects
        foreach (GameObject g in pauseObjects)
        { g.SetActive(false); }
        //Finally, load to main menu
        SceneManager.LoadScene("Main Menu");
    }

    //Used with the pause>main menu>no button (currently dummied out)
    public void PauseNotSureButton()
    {
        //this.GetComponent<AudioSource>().Play(); HELPME
        //If the player is not sure they want to quit to main, hides the options regarding that
        //currently dummied out
        /*
        foreach (GameObject g in hiddenPauseObjects)
        { g.SetActive(false); }
        */
    }

    //Used with win/loss screen>next and main menu>credits
    public void WinLossNextButton()
    {
        //this.GetComponent<AudioSource>().Play(); HELPME
        StartCoroutine(DelaySceneLoad("Credits Screen"));
    }

    IEnumerator DelaySceneLoad(string scene)
    {
        yield return new WaitForSecondsRealtime(.25f);
        SceneManager.LoadScene(scene);
    }
}
