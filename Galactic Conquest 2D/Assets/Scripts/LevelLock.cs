using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLock : MonoBehaviour
{
    public static int worlds = 1;
    public static int levels = 3;

    private int worldIndex;
    private int levelIndex;


    // Start is called before the first frame update
    void Start()
    {
        //PlayersPrefs.DeleteAll();
        LevelLocks();
    }

    // Update is called once per frame
    void LevelLocks()
    {
        for (int i = 0; i < worlds; i++)
        {
            for (int j = 1; j < levels; j++)
            {
                worldIndex = (i + 1);
                levelIndex = (j + 1);

                if(!PlayerPrefs.HasKey("level"+worldIndex.ToString() + ":" + levelIndex.ToString()))
                {
                    PlayerPrefs.SetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString(), 0);
                }
            }
        }
    }
}
