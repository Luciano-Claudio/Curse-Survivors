using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [System.Serializable]
    private class Monsters : IComparable
    {
        public int monsterNumber;

        public int minutes;
        public int quantity;
        public int delay;
        internal int auxSec = 0;

        public bool moreThirty;
        public bool largeRespawnArea;

        public int CompareTo(object obj)
        {
            if (!(obj is Monsters))
                throw new ArgumentException("Comparing error: argument is not a Monster");

            Monsters other = obj as Monsters;

            return minutes.CompareTo(other.minutes);
        }
    }

    public int MonsterNumber { get; private set; }

    [Header("Respawns")]
    [SerializeField] private Transform smallSpawnArea;
    [SerializeField] private Transform largeSpawnArea;
    [SerializeField] private Transform monsterLocal;

    [SerializeField] private List<Transform> smallSpawnList;
    [SerializeField] private List<Transform> largeSpawnList;

    [Header("Timer")]
    [SerializeField] private TimerController timer;
    [SerializeField] private int maxTimer;
    private int _random;

    [Header("Monsters")]
    [SerializeField] private GameObject monster;
    [SerializeField] private List<Monsters> monsterList;
    private List<List<Monsters>> monsterMatriz = new List<List<Monsters>>();


    void Awake()
    {
        monsterLocal = GameObject.Find("Monsters").transform;

        smallSpawnList = new List<Transform>(smallSpawnArea.GetComponentsInChildren<Transform>());
        largeSpawnList = new List<Transform>(largeSpawnArea.GetComponentsInChildren<Transform>());


        monsterList.Sort();
    }

    void Start()
    {
        for (int i = 0; i < maxTimer; i++)
        {
            List<Monsters> auxList = new List<Monsters>();
            foreach (Monsters m in monsterList)
            {
                if (m.minutes > i || m.minutes < i)
                    continue;
                if (m.minutes == i)
                    auxList.Add(m);
            }
            monsterMatriz.Add(auxList);
        }
    }

    void FixedUpdate()
    {
        if (monsterMatriz[timer.minutes] != null)
            Summon();
    }

    void Summon()
    {
        foreach (Monsters m in monsterMatriz[timer.minutes])
        {
            if (m.moreThirty && timer.seconds < 30)
                continue;
            if (m.auxSec != 0 && m.auxSec + m.delay > timer.seconds)
                continue;

            m.auxSec = 1 + timer.seconds;

            for (int i = 0; i < m.quantity; i++)
            {
                Vector3 pos = new Vector3();
                if (!m.largeRespawnArea)
                {
                    _random = UnityEngine.Random.Range(1, smallSpawnList.Count);
                    pos = smallSpawnList[_random].position;
                }
                else
                {
                    _random = UnityEngine.Random.Range(1, largeSpawnList.Count);
                    pos = largeSpawnList[_random].position;
                }
                MonsterNumber = m.monsterNumber;
                Instantiate(monster, pos, Quaternion.identity, monsterLocal);
            }
        }
    }
}
