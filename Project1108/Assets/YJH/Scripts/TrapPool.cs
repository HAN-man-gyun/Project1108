using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public class TrapPool : MonoBehaviour
    {
        private static TrapPool instance;
        public static TrapPool Instance
        {
            get
            {
                if (instance == null)
                {
                    return null;
                }
                return instance;
            }
        }
        private const int INIT_TRAP_COUNT = 30;
        private const int ADD_TRAP_COUNT = 10;
        [SerializeField] private GameObject trapPrefab;
        readonly Queue<GameObject> trapPool = new Queue<GameObject>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                if(instance != this)
                {
                    Destroy(this.gameObject);
                }
            }
            InitPool();
        }

        private void InitPool()
        {
            for (int i = 0; i < INIT_TRAP_COUNT; i++)
            {
                GameObject tempTrap = Instantiate(trapPrefab, transform);
                trapPool.Enqueue(tempTrap);
                tempTrap.SetActive(false);
            }
        }

        private void AddPool()
        {
            for (int i = 0; i < ADD_TRAP_COUNT; i++)
            {
                GameObject tempTrap = Instantiate(trapPrefab, transform);
                trapPool.Enqueue(tempTrap);
                tempTrap.SetActive(false);
            }
        }

        public void SetTrap(Vector3 trapPos)
        {
            if(trapPool.Count < 1)
            {
                AddPool();
            }
            GameObject tempTrap = trapPool.Dequeue();
            tempTrap.transform.SetParent(null);
            tempTrap.transform.position = trapPos;
            tempTrap.SetActive(true);
        }

        public void GetTrap(GameObject trap)
        {
            trapPool.Enqueue(trap);
            trap.transform.SetParent(transform);
            trap.SetActive(false);
        }
    }
}