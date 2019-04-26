using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;



public class threev3Combat : MonoBehaviour
{
    //Text used for health
    public Text enemy1TextHP;
    public Text enemy2TextHP;
    public Text enemy3TextHP;
    public Text meleeTextHP;
    public Text rangedTextHP;
    public Text healerTextHP;

    //Middle text displaying turn
    public Text turn;


    //Health of each hero starting at 100
    int meleeHealth = 100;
    int rangedHealth = 100;
    int healerHealth = 100;

    //Health of each enemy starting at 100
    int enemy1Health = 100;
    int enemy2Health = 100;
    int enemy3Health = 100;
    //
    bool meleeTurn = true;
    bool rangedTurn = true;
    bool healerTurn = true;
    bool enemyTurn = true;
    bool enemy2Turn = true;
    bool enemy3Turn = true;

    int randomHero = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");

        StartCoroutine(spaceBetweenTurns(meleeTurn, rangedTurn,healerTurn,enemyTurn,enemy2Turn,enemy3Turn));
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Melees Turn
    bool meleeAttackTurn()
    {
        //Will switch meleeTurn to false once over
        if (meleeTurn != false)
        {
            meleeTurn = true;
            turn.text = "Melee may now attack! (Q W E)";
        }

        //Melee could attack with Q W or E to hit respective enemy
        if (Input.GetKeyDown(KeyCode.Q) && meleeTurn)
        {
            Debug.Log("q was pressed.");
            //Sets health to health - damaged taken
            enemy1Health = meleeAttack(enemy1Health);
            //Displays new current health to screen
            enemy1TextHP.text = "Health: " + enemy1Health.ToString();
            //Sets melee turn to false once damage is done
            meleeTurn = false;
            return meleeTurn;
        }
        if (Input.GetKeyDown("w") && meleeTurn)
        {
            Debug.Log("w was pressed.");
            enemy2Health = meleeAttack(enemy2Health);
            enemy2TextHP.text = "Health: " + enemy2Health.ToString();
            meleeTurn = false;
            return meleeTurn;
        }
        if (Input.GetKeyDown("e") && meleeTurn)
        {
            enemy3Health = meleeAttack(enemy3Health);
            enemy3TextHP.text = "Health: " + enemy3Health.ToString();
            meleeTurn = false;
            return meleeTurn;
        }
        return meleeTurn;
            
    }
    //Healer Turn
    void healerAttackTurn()
    {
        //Will switch meleeTurn to false once over
        if (healerTurn != false)
        {
            healerTurn = true;
            turn.text = "Healer may now attack! (Q W E) or heal! (1 2 3)";
        }

            //Melee could attack with Q W or E to hit respective enemy
            if (Input.GetKeyDown(KeyCode.Q) && healerTurn)
        {
            Debug.Log("q was pressed.");
            //Sets health to health - damaged taken
            enemy1Health = healerAttack(enemy1Health);
            //Displays new current health to screen
            enemy1TextHP.text = "Health: " + enemy1Health.ToString();
            //Sets melee turn to false once damage is done
            healerTurn = false;
        }
        if (Input.GetKeyDown("w") && healerTurn)
        {
            Debug.Log("w was pressed.");
            enemy2Health = healerAttack(enemy2Health);
            enemy2TextHP.text = "Health: " + enemy2Health.ToString();
            healerTurn = false;

        }
        if (Input.GetKeyDown("e") && healerTurn)
        {
            enemy3Health = healerAttack(enemy3Health);
            enemy3TextHP.text = "Health: " + enemy3Health.ToString();
            healerTurn = false;
        }
        //Healer can heal using  1 2 or 3 to heal teamates/ using their turn
        if(Input.GetKeyDown("1") && healerTurn)
        {
            meleeHealth = healerHeal(meleeHealth);
            meleeTextHP.text = "Health: " + meleeHealth.ToString();
            healerTurn = false;
        }
        if (Input.GetKeyDown("2") && healerTurn)
        {
            rangedHealth = healerHeal(rangedHealth);
            rangedTextHP.text = "Health: " + rangedHealth.ToString();
            healerTurn = false;
        }
        if (Input.GetKeyDown("3") && healerTurn)
        {
            healerHealth = healerHeal(healerHealth);
            healerTextHP.text = "Health: " + healerHealth.ToString();
            healerTurn = false;
        }
    }


    //Ranged Turn
    void rangedAttackTurn()
    {
        //Will switch meleeTurn to false once over
        if (rangedTurn != false)
        {
            rangedTurn = true;
            turn.text = "Ranged may now attack! (Q W E)";
        }

            //Melee could attack with Q W or E to hit respective enemy
         if (Input.GetKeyDown(KeyCode.Q) && rangedTurn)
        {
            Debug.Log("q was pressed.");
            //Sets health to health - damaged taken
            enemy1Health = rangedAttack(enemy1Health);
            //Displays new current health to screen
            enemy1TextHP.text = "Health: " + enemy1Health.ToString();
            //Sets melee turn to false once damage is done
            rangedTurn = false;
        }
        if (Input.GetKeyDown("w") && rangedTurn)
        {
            Debug.Log("w was pressed.");
            enemy2Health = rangedAttack(enemy2Health);
            enemy2TextHP.text = "Health: " + enemy2Health.ToString();
            rangedTurn = false;

        }
        if (Input.GetKeyDown("e") && rangedTurn)
        {
            enemy3Health = rangedAttack(enemy3Health);
            enemy3TextHP.text = "Health: " + enemy3Health.ToString();
            rangedTurn = false;
        }
    }
    //Enemy will attack a random hero (for now) 
    bool enemyAttackTurn(int randomHero)
    {
        //Will switch meleeTurn to false once over
        if (enemyTurn != false)
        {
            enemyTurn = true;
            turn.text = "Enemy is now attacking!";
        }
        if (randomHero == 1 && enemyTurn)
        {
            turn.text = "Enemy is attacking  melee!";
            meleeHealth = enemyAttack(meleeHealth);
            meleeTextHP.text = "Health: " + meleeHealth.ToString();
            enemyTurn = false;
        }
        if (randomHero == 2 && enemyTurn)
        {
            turn.text = "Enemy is attacking ranged!";
            rangedHealth = enemyAttack(rangedHealth);
            rangedTextHP.text = "Health: " + rangedHealth.ToString();
            enemyTurn = false;
        }
        if (randomHero == 3 && enemyTurn)
        {
            turn.text = "Enemy is attacking healer!";
            healerHealth = enemyAttack(healerHealth);
            healerTextHP.text = "Health: " + healerHealth.ToString();
            enemyTurn = false;
        }
        return enemyTurn;
    }



    //Function takes in a health and deals damage to that hp (HERO CLASSES)
     int meleeAttack(int health)
    {
        int damage = Random.Range(10, 15);
        health -= damage;
        return health;
    }
    int rangedAttack(int health)
    {
        int damage = Random.Range(15, 25);
        health -= damage;
        return health;
    }
    int healerAttack(int health)
    {
        int damage = Random.Range(5, 15);
        health -= damage;
        return health;
    }
    int healerHeal(int health)
    {
        int heal = Random.Range(10, 15);
        health += heal;
        return health;
    }
    int enemyAttack(int health)
    {
        int damage = Random.Range(15, 20);
        health -= damage;
        return health;
    }

    private IEnumerator CoMeleeAttackTurnState()
    {
        // Enter State

        bool done = false;
        while(!done)
        {
            // Update State
            done = !meleeAttackTurn();
            yield return null;
        }

        // Exit State

    }


    IEnumerator spaceBetweenTurns(bool meleesTurn ,bool rangedsTurn,bool healerTurn,bool enemyTurn,bool enemy2Turn,bool enemy3Turn)
    {
        Debug.Log("Starting Turn Sequence");
        yield return StartCoroutine(CoMeleeAttackTurnState());
        Debug.Log("Melee Turn finished");
        // meleeAttackTurn();
        if (!meleesTurn)
        {
            turn.text = "Please wait";
            yield return new WaitForSeconds(1);
            rangedAttackTurn();
            if (!meleesTurn && !rangedsTurn)
            {
                turn.text = "Please wait";
                yield return new WaitForSeconds(1);
                healerAttackTurn();
            }
        }
        if (!meleeTurn && !rangedTurn && !healerTurn && enemyTurn)
        {
            turn.text = ("Player turn now over!");
            yield return new WaitForSeconds(3);
            randomHero = Random.Range(1, 4);
            Debug.Log(randomHero);
            enemyAttackTurn(randomHero);
            if (enemy2Turn)
            {
                turn.text = ("enemy 2 attacking");
                yield return new WaitForSeconds(3);
                randomHero = Random.Range(1, 4);
                Debug.Log(randomHero);
                enemyAttackTurn(randomHero);
            }
            if (enemy3Turn)
            {
                turn.text = ("Enemy 3 attacking");
                yield return new WaitForSeconds(3);
                randomHero = Random.Range(1, 4);
                Debug.Log(randomHero);
                enemyAttackTurn(randomHero);
            }
        }
        if (!meleeTurn && !rangedTurn && !healerTurn)
        {
            if (!meleeTurn && meleeHealth > 0)
            {
                meleeTurn = true;
            }
            if (!rangedTurn && rangedHealth > 0)
            {
                rangedTurn = true;
            }
            if (!healerTurn && healerHealth > 0)
            {
                healerTurn = true;
            }
            if(enemy1Health > 0)
                enemyTurn = true;
            if (enemy2Health > 0)
                enemy2Turn = true;
            if (enemy3Health > 0)
                enemy3Turn = true;
        }
    }
}
