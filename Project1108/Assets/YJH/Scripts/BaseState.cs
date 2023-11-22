using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public abstract class BaseState
    {
        protected PlayerYoo player;

        protected BaseState(PlayerYoo player)
        {
            this.player = player;
        }

        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateExit();
    }

    public class IdleState : BaseState
    {
        public IdleState(PlayerYoo player) : base(player) { }

        public override void OnStateEnter()
        {

        }

        public override void OnStateUpdate()
        {

        }

        public override void OnStateExit()
        {

        }
    }

    public class MoveState : BaseState
    {
        public MoveState(PlayerYoo player) : base(player) { }

        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        public override void OnStateEnter()
        {

        }

        public override void OnStateUpdate()
        {
            float axisX = Input.GetAxis(HORIZONTAL);
            float axisZ = Input.GetAxis(VERTICAL);
            Vector3 dir = (player.transform.forward * axisZ + player.transform.right * axisX).normalized;
            player.transform.position += player.MoveSpeed * Time.deltaTime * dir;
        }

        public override void OnStateExit()
        {

        }
    }

    public class GrowingState : BaseState
    {
        public GrowingState(PlayerYoo player) : base(player) { }

        public override void OnStateEnter()
        {
            // ToDo: 먹이 주기, 상호 작용 중 선택
        }

        public override void OnStateUpdate()
        {
            // ToDo: 해당 행동 중단 체크
        }

        public override void OnStateExit()
        {
            // ToDo: 중단 시 종료, 정상적으로 마무리 시 실행되는 무언가
        }
    }

    public class AttackState : BaseState
    {
        public AttackState(PlayerYoo player) : base(player) { }

        public override void OnStateEnter()
        {
            
        }

        public override void OnStateUpdate()
        {

        }

        public override void OnStateExit()
        {

        }
    }

    public class GatheringState : BaseState
    {
        public GatheringState(PlayerYoo player) : base(player) { }

        public override void OnStateEnter()
        {
            // ToDo: 채집물 채집 시작
        }

        public override void OnStateUpdate()
        {
            // ToDo: 채집 중 취소 체크
        }

        public override void OnStateExit()
        {
            // ToDo: 취소 시 인벤토리에 안넣고, 정상적으로 마무리 시 인벤토리에 넣기
        }
    }

    public class BuildingState : BaseState
    {
        public BuildingState(PlayerYoo player) : base(player) { }

        public override void OnStateEnter()
        {
            // ToDo: 건설 시작
        }

        public override void OnStateUpdate()
        {
            // ToDo: 건설 중 취소 체크
        }

        public override void OnStateExit()
        {
            // ToDo: 취소 시 건설 중지, 정상적으로 마무리 시 건설 완료
        }
    }

    public class FarmingState : BaseState
    {
        public FarmingState(PlayerYoo player) : base(player) { }

        public override void OnStateEnter()
        {
            // ToDo: 씨 뿌리기, 수확, 물주기 선택 화면 띄우기 (빈 땅일 경우 씨 뿌리기만, 빈 땅이 아닌 데 덜 자랐을 경우 물주기, 다 자랐을 경우 수확) 
        }

        public override void OnStateUpdate()
        {
            // ToDo: 씨 뿌리기, 수확, 물주기 체크 후 체크한 행동 끝까지 했는지 확인
        }

        public override void OnStateExit()
        {
            // ToDo: 행동 취소 시 중지, 정상적으로 마무리 시 해당 행동 마무리 했을 시 해야할 것들
        }
    }

    public class CraftingState : BaseState
    {
        public CraftingState(PlayerYoo player) : base(player) { }

        public override void OnStateEnter()
        {

        }

        public override void OnStateUpdate()
        {

        }

        public override void OnStateExit()
        {

        }
    }
}
