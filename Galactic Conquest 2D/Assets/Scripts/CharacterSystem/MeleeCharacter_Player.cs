using UnityEngine;
using System.Collections;

public class MeleeCharacter_Player : MeleeCharacter
{

    public override void OnStartTurn()
    {
        Debug.Log("Start Melee Turn");
    }

    public override void UpdateTurn()
    {
        Debug.Log("Melee Turn");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTakingTurn = false;
        }
    }

    public override void OnEndTurn()
    {
        Debug.Log("End Melee Turn");
    }
}
