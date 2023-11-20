using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public class ArrowPool : MonoBehaviour
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

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

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

        public void ShootArrow(Vector3 arrowPos, Vector3 arrowDir)
        {
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