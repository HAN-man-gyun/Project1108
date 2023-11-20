using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public class Arrow : MonoBehaviour
    {
        private Rigidbody arrowRigid;

        private void Awake()
        {
            arrowRigid = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            arrowRigid.AddForce(transform.forward * 300);
        }

        private void OnTriggerEnter()
        {
            arrowRigid.velocity = Vector3.zero;
            ArrowPool.Instance.GetArrow(this.gameObject);
        }
    }
}