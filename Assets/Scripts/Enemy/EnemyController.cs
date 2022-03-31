using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

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




    private string respName;

    private NavMeshAgent agent;
    private EnemyPath path;
    private CircleCollider2D _collider;

    private GameObject player;

    private RespawnController resp;

    //[SerializeField] private List<EnemyScriptableObject> _enemys;
    [SerializeField] private EnemyScriptableObject _enemy;


    void Awake()
    {

        Anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        path = GetComponent<EnemyPath>();
        _collider = GetComponentInChildren<CircleCollider2D>();
        //_mobscClliderMobs = GetComponentsInChildren<CircleCollider2D>().FirstOrDefault(x => x.CompareTag("MobsColliderMobs"));

        player = GameObject.Find("Player");
        resp = GameObject.Find("RespawnController").GetComponent<RespawnController>();


        respName = resp.MonsterName;

        _enemy = Resources.Load<EnemyScriptableObject>("Mobs/" + respName);
    }

    void Start()
    {

        Anim.runtimeAnimatorController = _enemy.AnimController;

        Name = _enemy.Name;

        Radius = _enemy.Radius;
        ColliderX = _enemy.ColliderX;
        ColliderY = _enemy.ColliderY;
        Size = _enemy.Size;

        Armor = _enemy.Armor;
        Life = _enemy.Life;
        Damage = _enemy.Damage;
        Recovery = _enemy.Recovery;
        LifeDrain = _enemy.LifeDrain;
        Cooldown = _enemy.Cooldown;
        AtkSpeed = _enemy.AtkSpeed;
        Speed = _enemy.Speed;
        Duration = _enemy.Duration;

        Amount = _enemy.Amount;

        Revival = _enemy.Revival;
        NonColision = _enemy.NonColision;

        Weapon = _enemy.Weapon;

        Time = _enemy.Time;

        Range = _enemy.Range <= Radius ? Radius + .1f : _enemy.Range;

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

        if (_enemy.Script)
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
