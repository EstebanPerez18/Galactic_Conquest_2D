using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealerCharacter_Player : HealerCharacter
{
    public Text turnDisplay;
    public override void OnStartTurn()
    {
        Debug.Log("Start Healer Player Turn");
        turnDisplay.text = "Healer Hero attacking!";
    }

    public override void UpdateTurn()
    {
        Debug.Log("Healer Player Turn");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetCharacter = combatController.enemyCharacters[0];
            targetCharacter.healthManager.ApplyDamage(Random.Range(5,10));
            isTakingTurn = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetCharacter = combatController.enemyCharacters[1];
            targetCharacter.healthManager.ApplyDamage(Random.Range(5, 10));
            isTakingTurn = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            targetCharacter = combatController.enemyCharacters[2];
            targetCharacter.healthManager.ApplyDamage(Random.Range(5, 10));
            isTakingTurn = false;
        }
        //HEAL TEAMMATES
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetCharacter = combatController.playerCharacters[0];
            targetCharacter.healthManager.AddHealth(Random.Range(10,15));
            isTakingTurn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetCharacter = combatController.playerCharacters[1];
            targetCharacter.healthManager.AddHealth(Random.Range(10,15));
            isTakingTurn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetCharacter = combatController.playerCharacters[2];
            targetCharacter.healthManager.AddHealth(Random.Range(10,15));
            isTakingTurn = false;
        }

    }

    public override void OnEndTurn()
    {
        Debug.Log("End Healer player Turn");
        turnDisplay.text = "";
    }
}

