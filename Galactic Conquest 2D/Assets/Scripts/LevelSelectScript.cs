using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectScript : MonoBehaviour
{
    private int worldIndex;
    private int levelIndex;

    void Start()
    {
        //loop thorugh all the worlds
        for (int i = 1; i <= LevelLock.worlds; i++)
        {
            if (Application.loadedLevelName == "World" + i)
            {
                worldIndex = i;
                CheckLockedLevels();
            }
        }
    }

    //Level to load on button click. Will be used for Level button click event 
    public void Selectlevel(string worldLevel)
    {
        Application.LoadLevel("Level" + worldLevel); //load the level
    }

    //uncomment the below code if you have a main menu scene to navigate to it on clicking escape when in World1 scene
    /*public void  Update (){
     if (Input.GetKeyDown(KeyCode.Escape) ){
      Application.LoadLevel("MainMenu");
     }   
    }*/

    //function to check for the levels locked
    void CheckLockedLevels()
    {
        //loop through the levels of a particular world
        for (int j = 1; j < LevelLock.levels; j++)
        {
            levelIndex = (j + 1);
            if ((PlayerPrefs.GetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString())) == 1)
            {
                GameObject.Find("LockedLevel" + (j + 1)).active = false;
                Debug.Log("Unlocked");
            }
        }
    }
}
