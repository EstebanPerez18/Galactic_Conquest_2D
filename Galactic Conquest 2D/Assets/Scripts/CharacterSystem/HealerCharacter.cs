using UnityEngine;
using System.Collections;

public class HealerCharacter : Character
{
    public override void OnEndTurn()
    {
        Debug.Log("Healer End Turn");
    }

    public override void OnStartTurn()
    {
        Debug.Log("Healer Start Turn");
    }

    public override void UpdateTurn()
    {
        Debug.Log("Healer Turn");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isTakingTurn = false;
        }
    }
    
}
