using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public class TrapBag : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                TrapPool.Instance.SetTrap(transform.position);
            }
        }
    }
}