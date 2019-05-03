using UnityEngine;
using System.Collections;

public class Boss : MeleeCharacter
{
    public override void OnStartTurn()
    {
        Debug.Log("Start Melee Turn");
    }

    public override void UpdateTurn()
    {
        Debug.Log("Enemy Melee Turn");
        // AI DECISIONS
        int random = Random.Range(0, 3);
        Debug.Log(random);
        targetCharacter = combatController.playerCharacters[Random.Range(0, 3)];
        targetCharacter.healthManager.ApplyDamage(Random.Range(20,35));
        isTakingTurn = false;


    }

    public override void OnEndTurn()
    {
        Debug.Log("End Melee Turn");
    }
}
