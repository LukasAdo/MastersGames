using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
   public Faction Faction;
    public BaseUnit UnitPrefab;
}

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Objects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public GameObject enemyPrefab; // Prefab of the enemy object
    public int health;
    public int attackPower;
    // Add more enemy-specific properties as needed
}

[CreateAssetMenu(fileName = "New Coin", menuName = "Scriptable Objects/Coin")]
public class CoinScriptableObject : ScriptableObject
{
    public GameObject coinPrefab; // Prefab of the coin object
    public int coinValue = 1;    // Value of each coin
}
[CreateAssetMenu(fileName = "New Key", menuName = "Scriptable Objects/Key")]
public class KeyScriptableObject : ScriptableObject
{
    public GameObject keyPrefab; // Prefab of the key object
    public string keyID;         // Unique ID for the key
}
[CreateAssetMenu(fileName = "New Broken Key", menuName = "Scriptable Objects/Broken Key")]
public class BrokenKeyScriptableObject : ScriptableObject
{
    public GameObject brokenKeyPrefab; // Prefab of the broken key object
    public string brokenKeyID;         // Unique ID for the broken key
}

[CreateAssetMenu(fileName = "New Door", menuName = "Scriptable Objects/Door")]
public class DoorScriptableObject : ScriptableObject
{
    public GameObject doorPrefab; // Prefab of the door object
    public string requiredKeyID;  // Key ID required to unlock this door
}
[CreateAssetMenu(fileName = "New Chicken", menuName = "Scriptable Objects/Animals/Chicken")]
public class ChickenScriptableObject : ScriptableObject
{
    public GameObject chickenPrefab; // Prefab of the chicken object
   
}
[CreateAssetMenu(fileName = "New Cow", menuName = "Scriptable Objects/Animals/Cow")]
public class CowScriptableObject : ScriptableObject
{
    public GameObject cowPrefab; // Prefab of the cow object
   
}
[CreateAssetMenu(fileName = "New Pig", menuName = "Scriptable Objects/Animals/Pig")]
public class PigScriptableObject : ScriptableObject
{
    public GameObject pigPrefab; // Prefab of the pig object
}
public enum Faction
{
    Hero = 0,
    Enemy = 1
}