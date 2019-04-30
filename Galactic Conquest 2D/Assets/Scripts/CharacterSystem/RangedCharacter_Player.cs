﻿using UnityEngine;
using System.Collections;

public class RangedCharacter_Player : RangedCharacter
{

    public override void OnStartTurn()
    {
        Debug.Log("Start Ranged Player Turn");
    }

    public override void UpdateTurn()
    {
        Debug.Log("Ranged Player Turn");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetCharacter = combatController.enemyCharacters[0];
            targetCharacter.healthManager.ApplyDamage(Random.Range(15,20));
            isTakingTurn = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetCharacter = combatController.enemyCharacters[1];
            targetCharacter.healthManager.ApplyDamage(Random.Range(15, 20));
            isTakingTurn = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            targetCharacter = combatController.enemyCharacters[2];
            targetCharacter.healthManager.ApplyDamage(Random.Range(15, 20));
            isTakingTurn = false;
        }
    }

    public override void OnEndTurn()
    {
        Debug.Log("End Ranged player Turn");
    }
}
