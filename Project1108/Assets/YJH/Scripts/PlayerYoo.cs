using Photon.Pun;
using System.Collections;
using UnityEngine;

namespace YJH
{
    public class PlayerYoo : MonoBehaviourPun
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";
        private const float ZERO = 0f;
        private const float ORIGIN_MOVESPEED = 10f;
        private const State INIT_STATE = State.IDLE;
        private const float ORIGIN_COLLECT_FASTER = 1f;

        private Camera mainCam;
        private float collectFaster;
        private bool dirFix;
        [SerializeField] private CollectableItem collectable = null;
        [SerializeField] private State playerState;
        private State PlayerState
        {
            get
            {
                return playerState;
            }
        }

        [SerializeField] private float moveSpeed;
        private float MoveSpeed
        {
            get
            {
                return moveSpeed;
            }
        }

        // 플레이어 상태를 나타내는 열거 형식
        enum State
        {
            IDLE, MOVE, FISHING, HARVESTING, COLLECTING
        }

        void Awake()
        {
            mainCam = Camera.main;
            moveSpeed = ORIGIN_MOVESPEED;
            collectFaster = ORIGIN_COLLECT_FASTER;
            playerState = INIT_STATE;
            dirFix = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!photonView.IsMine)
            {
                return;
            }

            //CheckCameraMove();
            CheckForwardDirectionFix();
            ChangeForwardDirection();
            CheckMove();
            Move();

            if(collectable != null)
            {
                DoCollecting();
            }
        }

        private void SetFowardDirectionFix(bool fix)
        {
            if(fix == dirFix)
            {
                return;
            }

            dirFix = fix;
        }

        private void CheckForwardDirectionFix()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (dirFix)
                {
                    return;
                }
                SetFowardDirectionFix(true);
            }

            if (Input.GetMouseButtonUp(1))
            {
                if (!dirFix)
                {
                    return;
                }
                SetFowardDirectionFix(false);
            }
        }

        //private void CheckCameraMove()
        //{
        //    if(Input.GetMouseButtonDown(1))
        //    {
        //        if(CameraManagerYoo.Instance.CamCanMove)
        //        {
        //            return;
        //        }
        //        CameraManagerYoo.Instance.SetPlayerCameraMovable(true);
        //    }

        //    if(Input.GetMouseButtonUp(1))
        //    {
        //        if (!CameraManagerYoo.Instance.CamCanMove)
        //        {
        //            return;
        //        }
        //        CameraManagerYoo.Instance.SetPlayerCameraMovable(false);
        //    }
        //}

        // 이동 키 누르는 중 인지 아닌지 체크해서 상태 변환하는 메서드
        private void CheckMove()
        {
            if(playerState == State.MOVE)
            {
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)
                && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
                {
                    ChangeState(State.IDLE);
                }
                return;
            }    

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                ChangeState(State.MOVE);
            }
        }

        private void CheckCollecting()
        {
            if(playerState != State.COLLECTING)
            {
                return;
            }
        }

        private void ChangeForwardDirection()
        {
            if(dirFix)
            {
                return;
            }

            Vector3 mainCamFront = mainCam.transform.forward;
            mainCamFront.y = ZERO;
            Vector3 dir = mainCamFront.normalized;
            transform.forward = dir;
        }

        private void Move()
        {
            if (playerState != State.MOVE)
            {
                return;
            }

            // 아래 3줄 + dir 메인 캠 기준 이동, 주석 처리된 dir 월드 포지션 기준 이동
            //Vector3 mainCamFront = mainCam.transform.forward;
            //Vector3 mainCamRight = mainCam.transform.right;
            //mainCamFront.y = ZERO;

            //Vector3 dir = (mainCamFront * axisZ + mainCamRight * axisX).normalized;
            float axisX = Input.GetAxis(HORIZONTAL);
            float axisZ = Input.GetAxis(VERTICAL);
            Vector3 dir = (transform.forward * axisZ + transform.right * axisX).normalized;
            // dir = (Vector3.right * axisX + Vector3.forward * axisZ + mainCamFront).normalized;
            //transform.forward = dir;
            transform.position += moveSpeed * Time.deltaTime * dir;
        }

        // 상태 변환하는 메서드
        private void ChangeState(State toState)
        {
            if (playerState == toState)
            {
                return;
            }

            playerState = toState;
        }

        private void CheckCollectable(Collider other)
        {
            if (other.GetComponent<CollectableItem>() == null)
            {
                return;
            }

            if (collectable == null)
            {
                collectable = other.GetComponent<CollectableItem>();
                Debug.Log("스크립트 찾음");
            }
        }

        private void DoCollecting()
        {
            if (collectable == null)
            {
                return;
            }

            if (collectable.ThisState == CollectableItem.State.Collectable && Input.GetKeyDown(KeyCode.E))
            {
                collectable.SetCollectTime(collectable.CollectTime / collectFaster);
                collectable.Collect();
                Debug.Log("스크립트 찾고 메서드 실행");
            }
        }

        private void RemoveCollectable(Collider other)
        {
            if (other.GetComponent<CollectableItem>() == null)
            {
                return;
            }

            if (collectable != null)
            {
                if (collectable.ThisState == CollectableItem.State.Collecting)
                {
                    collectable.StopCollecting();
                }
                collectable = null;
                Debug.Log("스크립트를 버렸습니다");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckCollectable(other);
        }

        private void OnTriggerExit(Collider other)
        {
            RemoveCollectable(other);
        }
    }
}