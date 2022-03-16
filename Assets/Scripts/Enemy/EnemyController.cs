using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public Animator Anim { get; private set; }

    public string Name { get; private set; }

    public float Radius { get; private set; }

    public float Armor { get; private set; }
    public float Life { get; private set; }
    public float Range { get; private set; }
    public float Damage { get; private set; }
    public float Recovery { get; private set; }
    public float LifeDrain { get; private set; }
    public float Cooldown { get; private set; }
    public float AtkSpeed { get; private set; }
    public float Speed { get; private set; }
    public float Duration { get; private set; }
    public float Area { get; private set; }

    public int Amount { get; private set; }

    public bool Revival { get; private set; }

    public GameObject Weapon { get; private set; }

    public int Time { get; private set; }



    private AIPath enemyPath;
    private AIDestinationSetter destination;

    private int i = 0;

    [SerializeField] private GameObject player;

    [SerializeField] private List<EnemyScriptableObject> _enemys;
    [SerializeField] private RespawnController resp;


    void Awake()
    {
        Anim = GetComponent<Animator>();
        enemyPath = GetComponent<AIPath>();
        destination = GetComponent<AIDestinationSetter>();

        player = GameObject.Find("Player");
        resp = GameObject.Find("RespawnController").GetComponent<RespawnController>();


        i = resp.MonsterNumber;
    }

    void Start()
    {
        Anim.runtimeAnimatorController = _enemys[i].AnimController;

        Name = _enemys[i].Name;

        Radius = _enemys[i].Radius;

        Armor = _enemys[i].Armor;
        Life = _enemys[i].Life;
        Damage = _enemys[i].Damage;
        Recovery = _enemys[i].Recovery;
        LifeDrain = _enemys[i].LifeDrain;
        Cooldown = _enemys[i].Cooldown;
        AtkSpeed = _enemys[i].AtkSpeed;
        Speed = _enemys[i].Speed;
        Duration = _enemys[i].Duration;
        Area = _enemys[i].Area;

        Amount = _enemys[i].Amount;

        Revival = _enemys[i].Revival;

        Weapon = _enemys[i].Weapon;

        Time = _enemys[i].Time;

        destination.target = player.transform;

        enemyPath.radius = Radius;
        enemyPath.maxSpeed = Speed;

        Range = _enemys[i].Range < 1.11f ? 1.11f : _enemys[i].Range;
        enemyPath.endReachedDistance = Range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
