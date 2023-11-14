using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class InvenManager : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;
    public Slot equip;

    private void Start()
    {
        items = new List<Item>();
        //slots = slotParent.GetComponentsInChildren<Slot>();
    }

    void Update()  
    {
        //FreshSlot();
    }

    public void Item()
    { 
    }

    public void FreshSlot(Item _item)
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
            if (slots[i].item.itemCode == _item.itemCode)
            {
                slots[i].count += 1;
            }
        }
        for (; i < slots.Length; i++)
        {
            //slots[i].item = null;
        }
    }

    public void AddItem(Item _item)
    {
        if (CheckInven(_item))
        {

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (_item.itemCode == slots[i]._item.itemCode)
                    {
                        slots[i]._count += 1;
                        return;
                    }
                }
            }
        }
        else
        {
            if (items.Count < slots.Length)
            {
                items.Add(_item);
                FreshSlot(_item);
            }
            else
            {
                print("°¡¹æÀÌ ²Ë Âü");
            }
        }
    }

    private bool CheckInven(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i]._item != null)
            {
                if (_item.itemCode == slots[i]._item.itemCode)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void Equip(int i)
    {
        if (slots[i - 1].item != null)
        {
            equip.item = slots[i - 1].item;
        }
    }

    public void RemoveItem()
    {
        if (equip.item != null)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (equip._item.itemCode == slots[i]._item.itemCode)
                {
                    if (slots[i].count > 0)
                    {
                        slots[i].count -= 1;

                        if (slots[i].count == 0)
                        {
                            Debug.Log(items[i].itemCode);
                            Debug.Log(equip._item.itemCode);
                            slots[i].item = null;

                            slots[i].count = 0;

                            items.RemoveAt(FindItem(i));

                            equip.item = null;
                            equip.count = 0;

                        }
                    }
                    return;
                }
            }
        }
    }

    private int FindItem(int num)
    {
        for (int i =0; i<items.Count; i++)
        {
            if (items[i].itemCode == items[num].itemCode)
            {
                return i;
            }
        }
        return 0;
    }
}

