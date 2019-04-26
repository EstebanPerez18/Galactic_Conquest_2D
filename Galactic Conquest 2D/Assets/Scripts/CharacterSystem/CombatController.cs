using UnityEngine;
using System.Collections;
/// <summary>
/// Control combat of 2 sets of characters
/// State machine turn control
/// 
/// </summary>
public class CombatController : MonoBehaviour
{
    public Character[] playerCharacters;
    public Character[] enemyCharacters;
    // Use this for initialization
    void Start()
    {
        //foreach (Character character in playerCharacters)
        //{
        //    character.TakeTurn();
        //}
        StartCoroutine(CoCombatStateMachine());
    }
    
    private IEnumerator CoCombatStateMachine()
    {
        bool done = false;
        while (!done)
        {
            // Players Turn
            foreach (Character character in playerCharacters)
            {
                //Single character turn
                yield return character.StartCoroutine(character.CoTakeTurn());

                //Check if all enemies are dead
                bool won = true;
                foreach (Character enemy in enemyCharacters)
                {
                    if (!enemy.healthManager.IsDead)
                        won = false;
                }
                //Do something if won
            }

            // Enemys Turn
            foreach (Character character in enemyCharacters)
            {
                yield return character.StartCoroutine(character.CoTakeTurn());
            }
            // TODO: Add enemy array
        }
    }
}
