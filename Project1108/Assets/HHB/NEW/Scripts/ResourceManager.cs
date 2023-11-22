using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public Dictionary<int, GameObject> costumePrefabs = new Dictionary<int, GameObject>();
    //public Dictionary<int, GameObject> hairPrefabs = new Dictionary<int, GameObject>();
    //public Dictionary<int, GameObject> accPrefabs = new Dictionary<int, GameObject>();
    //public Dictionary<int, GameObject> bagPrefabs = new Dictionary<int, GameObject>();

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        InitCostumePrefabs();
        //InitHairPrefabs();
        //InitAccPrefabs();
        //InitBagPrefabs();
    }

    public void InitCostumePrefabs()
    {
        for (int i = 1; i < 4; i++)
        {
            GameObject costume = Resources.Load<GameObject>(i.ToString());
            if (costume != null)
            {
                costumePrefabs[i] = costume;
            }
            else { Debug.Log("Failed To Load Costume : " + i); }
        }
    }

    //public void InitHairPrefabs()
    //{
    //    for (int i = 11; i < 14; i++)
    //    {
    //        GameObject hair = Resources.Load<GameObject>(i.ToString());
    //        if (hair != null)
    //        {
    //            hairPrefabs[i] = hair;
    //        }
    //        else { Debug.Log("Failed To Load Hair : " + i); }
    //    }
    //}

    //public void InitAccPrefabs()
    //{
    //    for (int i = 21; i < 24; i++)
    //    {
    //        GameObject acc = Resources.Load<GameObject>(i.ToString());
    //        if (acc != null)
    //        {
    //            accPrefabs[i] = acc;
    //        }
    //        else { Debug.Log("Failed To Load Acc : " + i); }
    //    }
    //}

    //public void InitBagPrefabs()
    //{
    //    for (int i = 31; i < 34; i++)
    //    {
    //        GameObject bag = Resources.Load<GameObject>(i.ToString());
    //        if (bag != null)
    //        {
    //            bagPrefabs[i] = bag;
    //        }
    //        else { Debug.Log("Failed To Load Bag : " + i); }
    //    }
    //}

    public GameObject GetCustomPrefabFromID(int id)
    { 
        GameObject costume = Resources.Load<GameObject>(id.ToString());
        if (costume != null)
        {
            return costume;
        }
        else { Debug.Log("Failed To Load : " + id); return null; }
    }
}
