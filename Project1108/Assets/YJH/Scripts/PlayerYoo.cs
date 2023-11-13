using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYoo : MonoBehaviourPun, IMovable
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const float ZERO = 0f;
    private const float ORIGIN_MOVESPEED = 10f;
    private const State INIT_STATE = State.IDLE;

    private Camera mainCam;

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
        IDLE, MOVE, FISHING, HARVESTING, GATHERING
    }

    void Awake()
    {
        mainCam = Camera.main;
        moveSpeed = ORIGIN_MOVESPEED;
        playerState = INIT_STATE;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!photonView.IsMine)
        {
            return;
        }
        CheckMove();
        Move();
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
        if(playerState == toState)
        {
            return;
        }
        playerState = toState;
    }

    private void OnTriggerEnter(Collider other)
    {
        // To Do: 낚시, 채집, 기타 행동들 범위내에 들어왔을경우 체크 해야함
    }
}
