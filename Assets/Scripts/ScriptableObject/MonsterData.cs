using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/MonsterData")]
public class MonsterData : ScriptableObject
{
    //public int ID;
    public string Name;
    public string Grade;
    public float Speed;
    public int Health;
}
