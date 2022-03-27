using UnityEngine;

[CreateAssetMenu(fileName = "EnemysAttributes", menuName = "Enemys/New Enemy")]
public class EnemyScriptableObject : ScriptableObject
{

    public RuntimeAnimatorController AnimController;

    public string Name;

    public float Radius;
    public float ColliderX;
    public float ColliderY;
    public float Size;

    public float Armor;
    public float Life;
    public float Range;
    public float Damage;
    public float Recovery;
    public float LifeDrain;
    public float Cooldown;
    public float AtkSpeed;
    public float Speed;
    public float Duration;

    public int Amount;

    public bool Revival;
    public bool NonColision;

    public GameObject Weapon;

    public int Time;

    public bool Script;

}
