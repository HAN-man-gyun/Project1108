using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Crop
{
    public int id;
    public string name;
    public int quantity;
    public float growTime;
    public int harvestValue;

    public Crop(int id, string name, int quantity, float growTime, int harvestValue)
    {
        this.id = id;
        this.name = name;
        this.quantity = quantity;
        this.growTime = growTime;
        this.harvestValue = harvestValue;

    }
}

[Serializable]
public class Structure
{
    public int id;
    public string name;
    public int arrNum;

    public Structure(int id, string name, int arrNum)
    {
        this.id = id;
        this.name = name;
        this.arrNum = arrNum;
    }
}



[Serializable]
public class Character
{
    public int id;
    public int head;
    public int eye;
    public int costume;

    //public Character(int id, int head, int eye, int cosutme)
    //{
    //    this.id = id;
    //    this.head = head;
    //    this.eye = eye;
    //    this.costume = cosutme;
    //}
}

[Serializable]
public class ItemEntry
{
    public int itemID;
    public int quantity;

    public ItemEntry(int itemID, int quantity)
    {
        this.itemID = itemID;
        this.quantity = quantity;
    }
}


[Serializable]
public class Wolf
{
    public int id;
    public string petName;
    public float value1;

    public Wolf ReturnWolf(int id, string petName, float value1)
    {
        this.id = id;
        this.petName = petName;
        this.value1 = value1;
        return this;
    }
}

[Serializable]
public class PlayerData
{
    public List<Crop> crops = new List<Crop>();
    public List<ItemEntry> userItems = new List<ItemEntry>();
    public List<Structure> structures = new List<Structure>();
    public Wolf wolf = new Wolf();
    public Character character = new Character();
}

// DBRead
public partial class DataManager : MonoBehaviour
{
    public PlayerData playerData;
    private Test test;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }


    public void UpdateWolfDataToDB()
    {
        var request = new UpdateUserDataRequest
        {
            Permission = UserDataPermission.Public,
            Data = new Dictionary<string, string>
            {
                {
                    "Wolf",JsonConvert.SerializeObject(playerData.wolf)
                }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, (result) => { Debug.Log(result); }, (error) => { Debug.Log(error); });
    }

    #region LEGACY
    //public void SaveWolfData()
    //{
    //    test = GFUNC.FindTopLevelGameObject("Test").GetComponent<Test>();
    //    var request = new UpdateUserDataRequest
    //    {
    //        Permission = UserDataPermission.Public,
    //        Data = new Dictionary<string, string>
    //        {
    //            {
    //                "Wolf", JsonConvert.SerializeObject()
    //            }
    //        }
    //    };
    //    PlayFabClientAPI.UpdateUserData(request, (result) => { Debug.Log(result); }, (error) => { Debug.Log(error); });
    //}

    // LOAD LOGIC
    //public Wolf GetWolf()
    //{

    //}

    // LOAD LOGIC
    //public void GetWolfData()
    //{
    //    PlayFabClientAPI.GetUserData(new GetUserDataRequest(), (result) =>
    //    {
    //        if (result.Data != null && result.Data.ContainsKey("Wolf"))
    //        {
    //            Wolf wolf = JsonConvert.DeserializeObject<Wolf>(result.Data["Wolf"].Value);
    //            int wolfId = wolf.id;
    //            string wolfName = wolf.petName;
    //            float value = wolf.value1;
    //            SaveWolf(wolfId, wolfName, value);
    //            //playerData.wolf = GetWolf();
    //        }
    //    },
    //    (error) => { Debug.Log(error); });
    //}

    //// SAVE
    //public void SaveWolf(int DataId, string DatapetName, float Datavalue)
    //{
    //    Wolf wolf = GFUNC.FindTopLevelGameObject("Test").GetComponent<Test>().wolf;
    //    wolf.id = DataId;
    //    wolf.petName = DatapetName;
    //    wolf.value1 = Datavalue;
    //}
    #endregion
}
