using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
   public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }
    public List<Items_Kim> itemDB = new List<Items_Kim>();
}
