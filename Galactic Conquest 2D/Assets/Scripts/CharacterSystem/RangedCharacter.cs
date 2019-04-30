using UnityEngine;
using System.Collections;

public abstract class RangedCharacter : Character
{
    public override void Start()
    {
        base.Start();
        Debug.Log("Melee Start");
    }

    private void Update()
    {
        // Test
        if (Input.GetKeyDown(KeyCode.T))
        {
            healthManager.ApplyDamage(25);
        }
    }
}
