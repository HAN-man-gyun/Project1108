using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public class Arrow : MonoBehaviour
    {
        private Rigidbody arrowRigid;
        private float arrowPower;
        private float duringTime;

        private void Awake()
        {
            arrowRigid = GetComponent<Rigidbody>();
            arrowPower = 500f;
            duringTime = 5f;
        }

        private void OnEnable()
        {
            arrowRigid.AddForce(transform.forward * arrowPower);
            Invoke(nameof(BackToPool), duringTime);
        }

        private void OnTriggerEnter()
        {
            arrowRigid.velocity = Vector3.zero;
            BackToPool();
        }

        private void BackToPool()
        {
            if(!this.gameObject.activeSelf)
            {
                return;
            }
            ArrowPool.Instance.GetArrow(this.gameObject);
        }
    }
}