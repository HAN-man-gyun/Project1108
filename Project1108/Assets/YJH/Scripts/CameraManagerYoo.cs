using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace YJH
{
    public class CameraManagerYoo : MonoBehaviour
    {
        private static CameraManagerYoo instance;
        public static CameraManagerYoo Instance
        {
            get { return instance; }
        }

        [SerializeField] private CinemachineFreeLook playerFreeLook = null;
        private float originYAxisSpeed;
        private float originXAxisSpeed;
        private bool camCanMove;
        public bool CamCanMove
        {
            get { return camCanMove; }
        }
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
                    Destroy(gameObject);
                }
            }

            if(GameObject.Find("PlayerFreeLook").GetComponent<CinemachineFreeLook>() == null)
            {
                return;
            }
            playerFreeLook = GameObject.Find("PlayerFreeLook").GetComponent<CinemachineFreeLook>();
            originYAxisSpeed = playerFreeLook.m_YAxis.m_MaxSpeed;
            originXAxisSpeed = playerFreeLook.m_XAxis.m_MaxSpeed;
            playerFreeLook.m_YAxis.m_MaxSpeed = 0;
            playerFreeLook.m_XAxis.m_MaxSpeed = 0;
            camCanMove = false;
        }

        public void SetPlayerCameraMovable(bool canMove)
        {
            if(canMove == camCanMove)
            {
                return;
            }

            if(canMove)
            {
                playerFreeLook.m_YAxis.m_MaxSpeed = originYAxisSpeed;
                playerFreeLook.m_XAxis.m_MaxSpeed = originXAxisSpeed;
                camCanMove = canMove;
            }

            if(!canMove)
            {
                playerFreeLook.m_YAxis.m_MaxSpeed = 0;
                playerFreeLook.m_XAxis.m_MaxSpeed = 0;
                camCanMove = canMove;
            }
        }
    }
}