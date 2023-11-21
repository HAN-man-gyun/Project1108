using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public class Trap : MonoBehaviour
    {
        private const float DURING_TIME = 10f;
        private float randomTime;
        private float successRate;

        private void Awake()
        {
            successRate = 30f;
        }

        private void OnEnable()
        {
            if(successRate > Random.Range(0.0f, 100.0f))
            {
                randomTime = Random.Range(0, DURING_TIME);
                Invoke(nameof(BackToPool), randomTime);
                Debug.Log("덫에 동물이 잡혔습니다, 걸린 시간" + randomTime);
            }
            else
            {
                Invoke(nameof(BackToPool), DURING_TIME);
                Debug.Log("덫이 텅 비었습니다.");
            }
        }

        private void BackToPool()
        {
            if(!this.gameObject.activeSelf)
            {
                return;
            }
            TrapPool.Instance.GetTrap(this.gameObject);
        }
    }
}