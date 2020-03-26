using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Control combat of 2 sets of characters
/// State machine turn control
/// 
/// </summary>
public class CombatController : MonoBehaviour
{
    public Character[] playerCharacters;
    public Character[] enemyCharacters;
    public Text turnDisplay;
    // Use this for initialization
    void Start()
    {
        foreach (Character character in playerCharacters)
        {
            character.combatController = this;
        }
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
                    turnDisplay.text = "Enemies are attacking!";
                    if (!enemy.healthManager.IsDead)
                        won = false;
                }
                //Do something if won
                if(won)
                {
                    SceneManager.LoadScene("Stronghold 1");
                }
            }

            // Enemys Turn
            foreach (Character character in enemyCharacters)
            {
                //Single character turn
                if (!character.healthManager.IsDead)
                    yield return new WaitForSeconds(1);
                yield return character.StartCoroutine(character.CoTakeTurn());

                //Check if all enemies are dead
                bool won = true;
                //If heros are dead; enemies win
                foreach (Character enemy in playerCharacters)
                {
                    if (!enemy.healthManager.IsDead)
                        won = false;
                }
                if (won)
                {
                    SceneManager.LoadScene("Stronghold 1");
                }
            }
        }
    }
}
