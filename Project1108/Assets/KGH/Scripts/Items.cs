using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Item")]
public enum ItemType
{
    one,
    two
}

[System.Serializable]
public class Items
{
    public int itemCode;
    public string itemName;
    public int fullQuantity; // 최대 수량
    public Sprite itemImage; // 매니저에서 코드랑 매칭시켜야됨
    public bool stackAble;
    public ItemType itemType;
}