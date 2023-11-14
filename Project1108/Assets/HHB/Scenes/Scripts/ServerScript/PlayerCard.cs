using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class PlayerCard : MonoBehaviourPunCallbacks
{
    Transform lobbyUI;
    Transform playerCard;

    // 인스턴스시 위치지정
    public void Start()
    {
        GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject root in roots)
        {
            if (root.name == "LobbyUI")
            {
                lobbyUI = root.transform;
            }
        }

        playerCard = lobbyUI.transform.GetChild(0);
        this.transform.SetParent(playerCard);
        this.transform.localScale = Vector3.one;
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, 0f);
        photonView.RPC("PrintUserNames", RpcTarget.AllBuffered);
    }

    // 이름 동기화
    [PunRPC]
    public void PrintUserNames()
    {
        TextMeshProUGUI text = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Hashtable customProperties = PhotonNetwork.CurrentRoom.CustomProperties;
        text.text = customProperties[this.transform.gameObject.GetComponent<PhotonView>().Owner.NickName.ToString()].ToString();
    }


    // 유저가 방 떠날시 playerCard 파괴 & Hashtable 제거
    public override void OnLeftRoom()
    {
        Hashtable customProperties = PhotonNetwork.CurrentRoom.CustomProperties;
        foreach (var prop in customProperties)
        {
            if (prop.Key.ToString() == PhotonNetwork.NickName)
            { 
                customProperties.Remove(prop.Key);
            }
        }
        PhotonNetwork.CurrentRoom.SetCustomProperties(customProperties);
        PhotonNetwork.Destroy(this.gameObject);
    }
}
