using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public class Bow : MonoBehaviour
    {
        private const string AIMING_CAM = "PlayerAiming";
        private const string FREELOOK_CAM = "PlayerFreeLook";

        private RaycastHit hit;
        private CinemachineFreeLook aimingCam;
        private CinemachineFreeLook freeLookCam;
        // Start is called before the first frame update
        void Awake()
        {
            aimingCam = GameObject.Find(AIMING_CAM).GetComponent<CinemachineFreeLook>();
            freeLookCam = GameObject.Find(FREELOOK_CAM).GetComponent<CinemachineFreeLook>();
        }

        // Update is called once per frame
        void Update()
        { 
            if(Input.GetMouseButtonDown(0))
            {
                aimingCam.Priority = 20;
                aimingCam.m_XAxis.Value = freeLookCam.m_XAxis.Value;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 camPos = Camera.main.transform.position;
                Vector3 camRot = Camera.main.transform.forward;
                Physics.Raycast(camPos, camRot, out hit);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Vector3 arrowDir;
                arrowDir = hit.point - transform.position;
                arrowDir.Normalize();
                if(hit.collider == null)
                {
                    arrowDir = Camera.main.transform.forward;
                }
                ArrowPool.Instance.ShootArrow(transform.position + (arrowDir.normalized * 2) , arrowDir);
                aimingCam.Priority = 10;
                freeLookCam.m_XAxis.Value = aimingCam.m_XAxis.Value;
            }
        }
    }
}