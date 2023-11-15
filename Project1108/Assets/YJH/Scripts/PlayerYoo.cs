using Photon.Pun;
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
        [SerializeField] private CollectableYoo collectable = null;
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
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!photonView.IsMine)
            {
                return;
            }
            CheckMove();
            Move();

            DoCollecting();
        }

        // 이동 키 누르는 중 인지 아닌지 체크해서 상태 변환하는 메서드
        private void CheckMove()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                ChangeState(State.MOVE);
            }
            else
            {
                ChangeState(State.IDLE);
            }
        }

        // IMovable 상속 시 사용해야 하는 Move 메서드
        private void Move()
        {
            if (playerState != State.MOVE)
            {
                return;
            }

            // 아래 3줄 + dir 메인 캠 기준 이동, 주석 처리된 dir 월드 포지션 기준 이동
            Vector3 mainCamFront = mainCam.transform.forward;
            Vector3 mainCamRight = mainCam.transform.right;
            mainCamFront.y = ZERO;

            float axisX = Input.GetAxis(HORIZONTAL);
            float axisZ = Input.GetAxis(VERTICAL);
            Vector3 dir = (mainCamFront * axisZ + mainCamRight * axisX).normalized;
            // dir = (Vector3.right * axisX + Vector3.forward * axisZ + mainCamFront).normalized;
            transform.forward = dir;
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
            if (other.GetComponent<CollectableYoo>() == null)
            {
                return;
            }

            if (collectable == null)
            {
                collectable = other.GetComponent<CollectableYoo>();
                Debug.Log("스크립트 찾음");
            }
        }

        private void DoCollecting()
        {
            if (collectable == null)
            {
                return;
            }

            if (collectable.ThisState == CollectableYoo.State.Collectable && Input.GetKeyDown(KeyCode.Space))
            {
                collectable.SetCollectTime(collectable.CollectTime / collectFaster);
                collectable.Collect();
                Debug.Log("스크립트 찾고 메서드 실행");
            }
        }

        private void RemoveCollectable(Collider other)
        {
            if (other.GetComponent<CollectableYoo>() == null)
            {
                return;
            }

            if (collectable != null)
            {
                if (collectable.ThisState == CollectableYoo.State.Collecting)
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