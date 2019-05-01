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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetCharacter = combatController.enemyCharacters[0];
            targetCharacter.healthManager.ApplyDamage(Random.Range(10, 15));
            isTakingTurn = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetCharacter = combatController.enemyCharacters[1];
            targetCharacter.healthManager.ApplyDamage(Random.Range(10, 15));
            isTakingTurn = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            targetCharacter = combatController.enemyCharacters[2];
            targetCharacter.healthManager.ApplyDamage(Random.Range(10, 15));
            isTakingTurn = false;
        }
    }

    public override void OnEndTurn()
    {
        Debug.Log("End Melee Turn");
    }
}
