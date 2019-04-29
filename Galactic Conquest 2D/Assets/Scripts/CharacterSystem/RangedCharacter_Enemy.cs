using UnityEngine;
using System.Collections;

public class RangedCharacter_Enemy : RangedCharacter
{
    public override void OnStartTurn()
    {
        Debug.Log("Start Enemy Ranged Turn");
    }

    public override void UpdateTurn()
    {
        Debug.Log("Enemy Ranged");
        // AI DECISIONS
        targetCharacter = combatController.playerCharacters[Random.Range(0, 3)];
        targetCharacter.healthManager.ApplyDamage(Random.Range(15, 20));
        isTakingTurn = false;


    }

    public override void OnEndTurn()
    {
        Debug.Log("End Enemy Ranged");
    }
}
