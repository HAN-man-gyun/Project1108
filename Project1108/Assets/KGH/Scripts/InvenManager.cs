using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
            slots[i].count += 1;
        }
        for (; i < slots.Length; i++)
        {
            //slots[i].item = null;
        }
    }

    public void AddItem(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                if (_item.itemCode == slots[i]._item.itemCode)
                {
                    slots[i].count += 1;
                    return;
                }
            }
        }
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("°¡¹æÀÌ ²Ë Âü");
        }
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
                if (equip._item.itemCode == items[i].itemCode)
                {
                    Debug.Log(equip._item.itemCode);
                    Debug.Log(items[i].itemCode);                    
                    slots[i].count -= 1;
                    return;
                }
            }
        }
    }
}

