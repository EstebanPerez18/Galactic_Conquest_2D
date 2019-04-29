using UnityEngine;
using System.Collections;
using MichaelWolfGames.DamageSystem;
/// <summary>
/// This represents ANY character in the game.
/// - Can attack an "enemy"
/// - Update UI Text
/// - Have Health, take damage, die.
/// - Have a turn.
/// </summary>
public abstract class Character : MonoBehaviour
{
    public HealthManager healthManager;
    public int currentHealth = 100;
    public int enemyChosen = 0;

    public Character targetCharacter;
    public CombatController combatController;

    public bool isTakingTurn = false;
    public abstract void OnStartTurn();
    public abstract void UpdateTurn();
    public abstract void OnEndTurn();

    public virtual void Start()
    {
        Debug.Log("Default Start");
        
    }



    public IEnumerator CoTakeTurn()
    {
        if (healthManager.IsDead == false)
        {
            isTakingTurn = true;
            // Enter State
            OnStartTurn();
            while (isTakingTurn)
            {
                // Update State
                UpdateTurn();
                //done = !meleeAttackTurn();
                yield return null;
            }
            OnEndTurn();
        }
    }
}
