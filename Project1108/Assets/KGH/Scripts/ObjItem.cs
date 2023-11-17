using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ObjItem : MonoBehaviour
{
    [Header("아이템")]
    public Items item;
    [Header("아이템 이미지")]
    public Sprite itemImage;

    void Start()
    {
        itemImage = item.itemImage;
    }
    public Items ClickItem()
    {
        return this.item;
    }
}
