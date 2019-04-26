using UnityEngine;
using System.Collections;

public class MeleeCharacter_Enemy : MeleeCharacter
{

    public override void OnStartTurn()
    {
        Debug.Log("Start Melee Turn");
    }

    public override void UpdateTurn()
    {
        Debug.Log("Melee Turn");
        // AI DECISIONS


    }

    public override void OnEndTurn()
    {
        Debug.Log("End Melee Turn");
    }
}
