using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAttributes", menuName = "Characters/New Character")]
public class PlayerScriptableObject : ScriptableObject
{
    public RuntimeAnimatorController AnimController;

    public string Name;

    public float Armor;
    public float Life;
    public float Damage;
    public float Recovery;
    public float LifeDrain;
    public float Magnet;
    public float Lucky;
    public float Cooldown;
    public float AtkSpeed;
    public float Speed;
    public float Duration;
    public float Area;
    public float ExpGain;
    public float MoreCoin;

    public int Amount;

    public bool Revival;

    public GameObject FirstWeapon;
    public GameObject SecondWeapon;
}
