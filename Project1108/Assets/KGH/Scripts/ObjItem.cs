using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjItem : MonoBehaviour
{
    [Header("아이템")]
    public Item item;
    [Header("아이템 이미지")]
    public Sprite itemImage;

    void Start()
    {
        itemImage = item.itemImage;
    }
    public Item ClickItem()
    {
        return this.item;
    }   
}
