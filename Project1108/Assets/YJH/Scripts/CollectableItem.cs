using System.Collections;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// 해당 클래스는 필드 채집물 클래스 입니다. 최종 업데이트 {유준호 23/11/14}
/// </summary>
namespace YJH
{
    public class CollectableItem : MonoBehaviourPun, ICollectable
    {
        /// <summary>
        /// 채집물의 이름입니다. 미지정시 default로 설정됩니다.
        /// </summary>
        protected string itemName = default;
        /// <summary>
        /// 채집물의 재생성 시간입니다. 미지정시 default로 설정됩니다.
        /// </summary>
        protected float regenTime = default;
        /// <summary>
        /// 채집물의 트랜스폼입니다. 미지정시 default로 설정됩니다.
        /// </summary>
        protected Transform thisTransform = default;
        /// <summary>
        /// 채집물의 채집 가능 크기입니다. 미지정시 default로 설정됩니다.
        /// </summary>
        protected Vector3 collectableScale = default;
        /// <summary>
        /// 채집물의 채집 후 크기입니다. 미지정시 default로 설정됩니다.
        /// </summary>
        protected Vector3 collectedScale = default;

        /// <summary>
        /// 채집물 채집하는데 걸리는 시간입니다. 미지정시 default로 설정됩니다.
        /// </summary>
        protected float collectTime = default;
        public float CollectTime
        {
            get
            {
                return collectTime;
            }
        }

        /// <summary>
        /// 채집물의 상태입니다. 미지정시 default로 설정됩니다.
        /// </summary>
        protected State state = default;
        public State ThisState
        {
            get { return state; }
        }

        public enum State
        {
            Collectable, Collecting, Collected, CollectCanceled
        }

        /// <summary>
        /// 채집물 채집 메소드
        /// </summary>
        public virtual void Collect()
        {
            if (state != State.Collectable)
            {
                Debug.Log(itemName + "가 채집 가능한 상태가 아닙니다.");
                return;
            }

            CollectOnPhoton();
            //if(PhotonNetwork.PlayerList.Length > 1)
            //{
            //    photonView.RPC("CollectOnPhoton", RpcTarget.Others);
            //}
        }

        //[PunRPC]
        protected virtual void CollectOnPhoton()
        {
            StartCoroutine(Collecting());
        }

        /// <summary>
        /// 채집물 재생성 메소드
        /// </summary>
        protected virtual void Regen()
        {
            if (state != State.Collected)
            {
                Debug.Log(itemName + "가 재생성 가능한 상태가 아닙니다.");
                return;
            }

            RegenOnPhoton();
            //if (PhotonNetwork.PlayerList.Length > 1)
            //{
            //    photonView.RPC("RegenOnPhoton", RpcTarget.Others);
            //}
        }

        //[PunRPC]
        protected virtual void RegenOnPhoton()
        {
            StartCoroutine(Regenerate());
        }

        /// <summary>
        /// 채집물 채집 코루틴
        /// </summary>
        protected virtual IEnumerator Collecting()
        {
            state = State.Collecting;
            float time = 0f;
            while (time < collectTime)
            {
                time += Time.deltaTime;
                yield return null;

                if (state == State.Collected)
                {
                    yield break;
                }

                if (state == State.CollectCanceled)
                {
                    state = State.Collectable;
                    Debug.Log("채집이 중단되었습니다.");
                    yield break;
                }
            }
            thisTransform.localScale = collectedScale;
            state = State.Collected;
            Debug.Log(itemName + " 획득");
            Regen();
        }

        /// <summary>
        /// 채집물 재생성 코루틴
        /// </summary>
        protected virtual IEnumerator Regenerate()
        {
            float time = 0f;
            while (time < regenTime)
            {
                time += Time.deltaTime;
                yield return null;

                if (state == State.Collectable)
                {
                    yield break;
                }
            }
            thisTransform.localScale = collectableScale;
            state = State.Collectable;
            Debug.Log(itemName + " 생성");
        }

        /// <summary>
        /// 채집 중단 메소드
        /// </summary>
        public void StopCollecting()
        {
            state = State.CollectCanceled;
        }

        /// <summary>
        /// 채집하는데 걸리는 시간 설정 메소드
        /// </summary>
        /// <param name="time"> 해당 매개 변수에 입력한 값이 채집하는데 걸리는 시간으로 반영됨 </param>
        public void SetCollectTime(float time)
        {
            collectTime = time;
        }
    }
}