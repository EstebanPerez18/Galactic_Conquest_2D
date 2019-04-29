using UnityEngine;
using System.Collections;

public abstract class MeleeCharacter : Character
{   
    public override void Start()
    {
        base.Start();
        Debug.Log("Melee Start");
    }

    private void Update()
    {
        // Test
        if(Input.GetKeyDown(KeyCode.T))
        {
            healthManager.ApplyDamage(Random.Range(10,15));
        }
    }

    //public override void OnStartTurn()
    //{
    //    Debug.Log("Start Melee Turn");
    //}

    //public override void UpdateTurn()
    //{
    //    Debug.Log("Melee Turn");
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        isTakingTurn = false;
    //    }
    //}

    //public override void OnEndTurn()
    //{
    //    Debug.Log("End Melee Turn");
    //}
}
