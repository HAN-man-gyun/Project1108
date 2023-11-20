using PlayFab.ClientModels;
using PlayFab;
using UnityEngine;
using Newtonsoft.Json;

public class Test : MonoBehaviour
{
    public Wolf wolf;
    // LOAD
    public int id;
    public string petName;
    public float value1;

    public void ApplyWolfDataToDataManager()
    {
        DataManager.Instance.playerData.wolf = wolf.ReturnWolf(id, petName, value1);
    }


    public void InitDBWolfData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), (result) =>
        {
            if (result.Data != null && result.Data.ContainsKey("Wolf"))
            {
                Wolf wolf = JsonConvert.DeserializeObject<Wolf>(result.Data["Wolf"].Value);
                ApplyWolfData(wolf.id, wolf.petName, wolf.value1);
                ApplyWolfDataToDataManager();
            }
        },
        (error) => { Debug.Log(error); });
    }



    public void ApplyWolfData(int DataId, string DatapetName, float Datavalue)
    {
        id = DataId;
        petName = DatapetName;
        value1 = Datavalue;
    }
}
