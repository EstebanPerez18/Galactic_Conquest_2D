using UnityEngine;
using System.Collections;

public class HealerCharacter_Enemy : HealerCharacter
{
    public override void OnStartTurn()
    {
        Debug.Log("Start Enemy Healer Turn");
    }

    public override void UpdateTurn()
    {
        Debug.Log("Enemy Healer");
        // AI DECISIONS
        targetCharacter = combatController.playerCharacters[Random.Range(0, 3)];
        targetCharacter.healthManager.ApplyDamage(Random.Range(5, 10));
        isTakingTurn = false;


    }

    public override void OnEndTurn()
    {
        Debug.Log("End Enemy Healer");
    }
}
