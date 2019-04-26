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

    // Use this for initialization
    void Start()
    {
        foreach (Character character in playerCharacters)
        {
            character.TakeTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
