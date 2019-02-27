using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public Text turnText;
    public Text playerText;
    public Text enemyText;

    int playerHealth = 100;
    int enemyHealth = 100;

    bool playerTurn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartPlayerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTurn && Input.GetKeyDown(KeyCode.Space) && (playerHealth != 0 || enemyHealth != 0))
        {
            PlayerHit();
            SwitchTurn();
        }
        if(playerHealth == 0)
        {
            turnText.text = "Oof! You died!";
            playerTurn = false;
        }
        if(enemyHealth == 0)
        {
            turnText.text = "Enemy has been kilt!";
        }


    }


    void StartPlayerTurn()
    {
        //Need to update text
        turnText.text = "Players turn! (Press space bar to attack) ";

    }


    void PlayerHit()
    {
        int damage = Random.Range(10, 25);
        enemyHealth -= damage;

        //Wont let health get to negative
        if(enemyHealth <= 0)
        {
            //Player Wins
            enemyHealth = 0;
        }
    }


    void SwitchTurn()
    {
        //Health updated every turn
        playerText.text = "Health: " + playerHealth;
        enemyText.text = "Health: " + enemyHealth;

        //Switches from player turn and enemy turn and vice versa
        playerTurn = !playerTurn;

        if (playerTurn)
        {
            StartPlayerTurn();
        }
        else
        {
            StartEnemyTurn();
        }
    }


    void StartEnemyTurn()
    {
        turnText.text = "Enemy is attacking!";
        //Wait a couple seconds to avoid attacking instantly
        StartCoroutine(EnemyTurn());


    }
    void EnemyHit()
    {
        int damage = Random.Range(10, 25);
        playerHealth -= damage;

        //Wont let health get to negative
        if (playerHealth <= 0)
        {
            //Enemy Wins
            playerHealth = 0;
        }
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        EnemyHit();
        if (enemyHealth != 0)
        {
            SwitchTurn();
        }

    }   
}
