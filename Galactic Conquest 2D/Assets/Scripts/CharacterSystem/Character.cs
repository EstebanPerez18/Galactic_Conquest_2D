using UnityEngine;
using System.Collections;

/// <summary>
/// This represents ANY character in the game.
/// - Can attack an "enemy"
/// - Update UI Text
/// - Have Health, take damage, die.
/// - Have a turn.
/// </summary>
public abstract class Character : MonoBehaviour
{
    public abstract void TakeTurn();
    public bool isDead = false;
}
