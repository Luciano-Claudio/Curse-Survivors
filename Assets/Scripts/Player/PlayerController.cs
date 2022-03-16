using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Character Lists
    [SerializeField] private List<PlayerScriptableObject> _characters;

    //Menu
    private int i = 0; //character choice

    private float menuArmor;
    private float menuLife;
    private float menuDamage;
    private float menuRecovery;
    private float menuLifeDrain;
    private float menuMagnet;
    private float menuLucky;
    private float menuCooldown;
    private float menuAtkSpeed;
    private float menuSpeed;
    private float menuDuration;
    private float menuArea;
    private float menuExpGain;
    private float menuMoreCoin;

    private int menuAmount;

    private bool menuRevival;

    //PlayerScriptableObjects atributes
    public Animator Anim { get; private set; }

    public string Name { get; private set; }

    public float Armor { get; private set; }
    public float Life { get; private set; }
    public float Damage { get; private set; }
    public float Recovery { get; private set; }
    public float LifeDrain { get; private set; }
    public float Magnet { get; private set; }
    public float Lucky { get; private set; }
    public float Cooldown { get; private set; }
    public float AtkSpeed { get; private set; }
    public float Speed { get; private set; }
    public float Duration { get; private set; }
    public float Area { get; private set; }
    public float ExpGain { get; private set; }
    public float MoreCoin { get; private set; }

    public int Amount { get; private set; }

    public bool Revival { get; private set; }

    public GameObject FirstWeapon { get; private set; }
    public GameObject SeccondWeapon { get; private set; }


    void Awake()
    {
        Anim = GetComponent<Animator>();

        //gameObject.AddComponent<PlayerMovement>();
    }
    private void Start()
    {
        Anim.runtimeAnimatorController = _characters[i].AnimController;

        Name = _characters[i].Name;

        Armor = _characters[i].Armor;
        Life = _characters[i].Life;
        Damage = _characters[i].Damage;
        Recovery = _characters[i].Recovery;
        LifeDrain = _characters[i].LifeDrain;
        Magnet = _characters[i].Magnet;
        Lucky = _characters[i].Lucky;
        Cooldown = _characters[i].Cooldown;
        AtkSpeed = _characters[i].AtkSpeed;
        Speed = _characters[i].Speed;
        Duration = _characters[i].Duration;
        Area = _characters[i].Area;
        ExpGain = _characters[i].ExpGain;
        MoreCoin = _characters[i].MoreCoin;

        Amount = _characters[i].Amount + menuAmount;

        Revival = _characters[i].Revival ? true : menuRevival;

        FirstWeapon = _characters[i].FirstWeapon;
        SeccondWeapon = _characters[i].SecondWeapon;
    }

    void Update()
    {

    }
}
