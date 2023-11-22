using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayerCustom : MonoBehaviour
{
    public Character character;

    public int customId;

    public void ApplyPlayerCustom()
    {
        DataManager.Instance.playerData.character.costume = character.ReturnCostume(customId);
    }

    public void InitDBCharacterData()
    { 
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), (result) => 
        {
            if (result.Data != null && result.Data.ContainsKey("Character"))
            {
                PlayerCustom playerCustom = JsonConvert.DeserializeObject<PlayerCustom>(result.Data["Character"].Value);
            }
        },
        (error) => { Debug.Log(error); });
    }

}
