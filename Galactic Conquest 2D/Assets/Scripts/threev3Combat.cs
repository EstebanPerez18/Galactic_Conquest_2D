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


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spaceBetweenTurns(meleeTurn, rangedTurn));
        // rangedAttackTurn();
        //healerAttackTurn();
        /* if(meleeTurn != false)
             meleeTurn = true;
             if (Input.GetKeyDown(KeyCode.Q) && meleeTurn)
             {
                 Debug.Log("q was pressed.");
                 enemy1Health = meleeAttack(enemy1Health);
                 enemy1TextHP.text = "Health: " + enemy1Health.ToString();
             meleeTurn = false;
             }
             else if (Input.GetKeyDown("w") && meleeTurn)
             {
                 Debug.Log("w was pressed.");
                 enemy2Health = meleeAttack(enemy2Health);
                 enemy2TextHP.text = "Health: " + enemy2Health.ToString();

             }
             else if (Input.GetKeyDown("e")&& meleeTurn)
             {
                 enemy3Health = meleeAttack(enemy3Health);
                 enemy3TextHP.text = "Health: " + enemy3Health.ToString();

             }
         */


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
            meleeTurn = false;

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



    IEnumerator spaceBetweenTurns(bool meleesTurn ,bool rangedsTurn)
    {

        meleeAttackTurn();
        if (!meleesTurn)
        {
            turn.text = "Please wait";
            yield return new WaitForSeconds(2);
            rangedAttackTurn();
            if (!meleesTurn && !rangedsTurn)
            {
                turn.text = "Please wait";
                yield return new WaitForSeconds(2);
                healerAttackTurn();
            }
        }
        if (!meleeTurn && !rangedTurn && !healerTurn)
        {
            turn.text = ("Player turn now over!");
        }
    }
}
