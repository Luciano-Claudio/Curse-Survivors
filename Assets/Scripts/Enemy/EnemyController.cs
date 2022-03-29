using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Animator Anim { get; private set; }

    public string Name { get; private set; }

    public float Radius { get; private set; }
    public float ColliderX { get; private set; }
    public float ColliderY { get; private set; }
    public float Size { get; private set; }

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

    public int Amount { get; private set; }

    public bool Revival { get; private set; }
    public bool NonColision { get; private set; }

    public GameObject Weapon { get; private set; }

    public int Time { get; private set; }




    private int i = 0;

    private NavMeshAgent agent;
    private EnemyPath path;
    [SerializeField] private CircleCollider2D _collider;

    private GameObject player;

    private RespawnController resp;

    [SerializeField] private List<EnemyScriptableObject> _enemys;


    void Awake()
    {
        Anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        path = GetComponent<EnemyPath>();
        _collider = GetComponentInChildren<CircleCollider2D>();

        player = GameObject.Find("Player");
        resp = GameObject.Find("RespawnController").GetComponent<RespawnController>();


        i = resp.MonsterNumber;

    }

    void Start()
    {

        Anim.runtimeAnimatorController = _enemys[i].AnimController;

        Name = _enemys[i].Name;

        Radius = _enemys[i].Radius;
        ColliderX = _enemys[i].ColliderX;
        ColliderY = _enemys[i].ColliderY;
        Size = _enemys[i].Size;

        Armor = _enemys[i].Armor;
        Life = _enemys[i].Life;
        Damage = _enemys[i].Damage;
        Recovery = _enemys[i].Recovery;
        LifeDrain = _enemys[i].LifeDrain;
        Cooldown = _enemys[i].Cooldown;
        AtkSpeed = _enemys[i].AtkSpeed;
        Speed = _enemys[i].Speed;
        Duration = _enemys[i].Duration;

        Amount = _enemys[i].Amount;

        Revival = _enemys[i].Revival;
        NonColision = _enemys[i].NonColision;

        Weapon = _enemys[i].Weapon;

        Time = _enemys[i].Time;

        Range = _enemys[i].Range <= Radius ? Radius + .1f : _enemys[i].Range;

        _collider.radius = Radius;
        _collider.transform.localPosition = new Vector3(ColliderX, ColliderY, 0);
        path._collider = _collider;

        Size = UnityEngine.Random.Range(Size - .5f, Size + .5f);
        transform.localScale = new Vector3(Size, Size, Size);

        path.size = Size;
        path.range = Range;
        path.nonColision = NonColision;


        path.speed = agent.speed = Speed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        if (NonColision)
        {
            agent.enabled = false;
            gameObject.AddComponent<NonCollision>();
        }

        if (_enemys[i].Script)
        {
            Type script = Type.GetType(Name);
            gameObject.AddComponent(script);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddComponent(string name)
    {
    }
}
