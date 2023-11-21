using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace YJH
{
    public class ArrowPool : MonoBehaviourPun
    {
        private static ArrowPool instance;
        public static ArrowPool Instance
        {
            get { 
                if(instance == null)
                {
                    return null;
                }
                return instance; }
        }
        private const int INIT_ARROW_COUNT = 30;
        private const int ADD_ARROW_COUNT = 10;
        [SerializeField] private GameObject arrowPrefab;
        readonly Queue<GameObject> arrowPool = new Queue<GameObject>();

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                if(instance != this)
                {
                    Destroy(gameObject);
                }
            }
            InitPool();
        }

        private void InitPool()
        {
            arrowPool.Clear();
            for (int i = 0; i < INIT_ARROW_COUNT; i++)
            {
                GameObject tempArrow = Instantiate(arrowPrefab, transform);
                arrowPool.Enqueue(tempArrow);
                tempArrow.SetActive(false);
            }
        }

        private void AddPool()
        {
            for (int i = 0; i < ADD_ARROW_COUNT; i++)
            {
                GameObject tempArrow = Instantiate(arrowPrefab, transform);
                arrowPool.Enqueue(tempArrow);
                tempArrow.SetActive(false);
            }
        }

        //public void ShootArrowPhoton(Vector3 arrowPos, Vector3 arrowDir)
        //{
        //    photonView.RPC(nameof(ShootArrow), RpcTarget.All, arrowPos, arrowDir);
        //}

        //[PunRPC]
        public void ShootArrow(Vector3 arrowPos, Vector3 arrowDir)
        {
            if(arrowPool.Count < 1)
            {
                AddPool();
            }
            GameObject arrowToShoot = arrowPool.Dequeue();
            arrowToShoot.transform.SetParent(null);
            arrowToShoot.transform.position = arrowPos;
            arrowToShoot.transform.forward = arrowDir;
            arrowToShoot.SetActive(true);
        }

        public void GetArrow(GameObject arrow)
        {
            arrow.transform.SetParent(transform);
            arrowPool.Enqueue(arrow);
            arrow.SetActive(false);
        }
    }
}