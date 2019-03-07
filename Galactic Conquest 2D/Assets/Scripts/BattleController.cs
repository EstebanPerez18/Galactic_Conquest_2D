using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleController : MonoBehaviour
{
    public Text turnText;
    public Text playerText;
    public Text enemyText;
    public Text player2Text;
    public Text player3Text;
    public Text enemy2Text;
    public Text enemy3Text;
    public Text playerAttackText;
    public Text playerAttack2Text;
    public Text playerAttack3Text;
    public Text canAttack;

    public Text enemyStatus;
    public Text enemy2Status;
    public Text enemy3Status;

    int playerHealth = 100;
    int player2Health = 100;
    int player3Health = 100;
    int enemyHealth = 100;
    int enemy2Health = 100;
    int enemy3Health = 100;

    bool playerTurn = true;
    bool heroTurn = true;
    bool hero2Turn = true;
    bool hero3Turn = true;
   // bool enemyTurn = false;
   // bool enemy2Turn = false;
    //bool enemy3Turn = false;
    // Start is called before the first frame update
    void Start()
    {
        StartPlayerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        displayHeroHealth();
        displayEnemyHealth();
        while (playerTurn)
        {

            optionsLeft();
            if (heroTurn)
            {
                //THEY CHOSE A VALID OPTION
                //SHOW WHO IS VALID TO HIT
                enemiesLeft();
                //MAKE SURE WHAT THEY ARE CHOOSING IS VALID/NOT DEAD
                int enemyChoosen = ChooseEnemy();
                while (enemyChoosen <= 0)
                {
                    canAttack.text = "This enemy is dead! Try to hit another!";
                    enemyChoosen = ChooseEnemy();
                }
                //HIT ENEMY
                Hit(enemyChoosen);
                heroTurn = false;

            }
            if (hero2Turn)
            {
                //THEY CHOSE A VALID OPTION
                //SHOW WHO IS VALID TO HIT
                enemiesLeft();
                //MAKE SURE WHAT THEY ARE CHOOSING IS VALID/NOT DEAD
                int enemyChoosen = ChooseEnemy();
                while (enemyChoosen <= 0)
                {
                    canAttack.text = "This enemy is dead! Try to hit another!";
                    enemyChoosen = ChooseEnemy();
                }
                //HIT ENEMY
                Hit(enemyChoosen);
                hero2Turn = false;

            }
            if (hero3Turn)
            {
                //THEY CHOSE A VALID OPTION
                //SHOW WHO IS VALID TO HIT
                enemiesLeft();
                //MAKE SURE WHAT THEY ARE CHOOSING IS VALID/NOT DEAD
                int enemyChoosen = ChooseEnemy();
                while (enemyChoosen <= 0)
                {
                    canAttack.text = "This enemy is dead! Try to hit another!";
                    enemyChoosen = ChooseEnemy();
                }
                //HIT ENEMY
                Hit(enemyChoosen);
                hero3Turn = false;

            }
            if (!heroTurn && !hero2Turn && !hero3Turn)
            {
                //SWITCH TO ENEMY TURN
                playerTurn = false;
            }

            /*
                 while(playerTurn)
                 {

                     //Will run to see if all heroes have gone
                     if (heroTurn || hero2Turn || hero3Turn)
                     {
                         endAndStartTurn(heroAttacking());
                         //Choose enemy to hit
                         int enemyToHit = ChooseEnemy();
                         //If enemies health is greater than 0, you can hit them
                         if(enemyToHit > 0)
                             Hit(enemyToHit);
                     }
                     if(!heroTurn && !hero2Turn && !hero3Turn)
                     {
                         SwitchTurn();
                     }
                 }
                 if(playerHealth == 0 && player2Health == 0 && player3Health == 0)
                 {
                     turnText.text = "Squad Wiped! RIP";
                     playerTurn = false;
                 }
                 if(enemyHealth == 0 && enemy2Health == 0 && enemy3Health == 0)
                 {
                     turnText.text = "Enemies have been kilt!";
                 }
                 */

        }
    }
    void displayEnemyHealth()
    {
        enemyText.text = "Health: " + enemyHealth;
        enemy2Text.text = "Health: " + enemy2Health;
        enemy3Text.text = "Health: " + enemy3Health;
    }
    //Displays all heroes health/updates health
    void displayHeroHealth()
    {
        playerText.text = "Health: " +playerHealth;
        player2Text.text = "Health: " +player2Health;
        player3Text.text = "Health: " + player3Health;
    }
    public bool endAndStartTurn(bool turn)
    {
        return !turn;
    }
    //Displays whether enemy is dead or not
    void enemiesLeft()
    {
        if(enemyHealth <= 0)
        {
            enemyStatus.text = "Alive";
        }
        else
        {
            enemyStatus.text = "Dead";
        }
        if(enemy2Health <= 0)
        {
            enemy2Status.text = "Alive";
        }
        else
        {
            enemy2Status.text = "Dead";
        }
        if(enemy3Health <= 0)
        {
            enemy3Status.text = "Alive";
        }
        else
        {
            enemy3Status.text = "Dead";
        }
    }
    void optionsLeft()
    {
        if (heroTurn)
        {
            //Print Q may attack
            playerAttackText.text = "Ready to attack!";


        }
        else
        {
            playerAttackText.text = "Already attacked";

        }
        if (hero2Turn)
        {
            //Print W may attack
            playerAttack2Text.text = "Ready to attack!";
        }
        else
        {
            playerAttack2Text.text = "Already attacked";
        }
        if (hero3Turn)
        {
            //Print E may attack
            playerAttack3Text.text = "Ready to attack!";
        }
        else
        {
            playerAttack3Text.text = "Already attacked";
        }
    }

    void Hit(int health)
    {
        int damage = Random.Range(10, 25);
        health -= damage;
    }

    public int ChooseEnemy()
    {
        while(true)
        { 
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                return enemyHealth;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                return enemy2Health;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                return enemy3Health;
            }
        }
    }
    //Hero chooses enemy to hit //MIGHT STILL BE USEFUL? \\
    /*public int ChooseEnemy()
    {
        bool firstChoice = Input.GetKeyDown(KeyCode.Alpha1);
        //Reset enemyChoosen for player to choose again
        while (true)
        {
            if (firstChoice && enemyChoosen[0] == 1)
            {
                return enemyHealth;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && Array.Find(enemyChoosen, s=>s.Equals(2))==2)
            {
                return enemy2Health;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && Array.Find(enemyChoosen, s => s.Equals(3)) == 3)
            {
                return enemy3Health;
            }
        }
    }
    */

    //Enemy chooses hero to hit/ they will choose a random hero (FOR NOW)
   /* public int ChooseHero()
    {
        int aiChoice = Random.Range(0, heroChoosen.Length);
        if(aiChoice == 1)
        {
            return 1;
        }
        else if(aiChoice == 2)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    */

    void StartPlayerTurn()
    {
        //Need to update text
        turnText.text = "Players turn! Choose hero to attack (Q,W,E) and choose an enemy to hit (1,2,3 on keyboard)";

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
