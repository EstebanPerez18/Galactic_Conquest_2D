using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnClick : MonoBehaviour
{
    public void doExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
