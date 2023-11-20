//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Unity.VisualScripting;
//using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class InventoryUI : MonoBehaviour
{
    Inventory_Kim inven;

    public GameObject slotUI;

    public GameObject inventoryPanel;
    bool activeInven = false;

    public Slot_Kim[] slots;
    public Transform slotHolder;

    public Button prevButton;
    public Button nextButton;

    private int invenNum_;
    public int invenNum
    {
        get { return invenNum_; }
        set
        {
            invenNum_ = value;
            ChangePage();
            Debug.Log(invenNum_);
        }
    }
    // Start is called before the first frame update

    private void Awake()
    {
        inven = Inventory_Kim.Instance;
    }
    void Start()
    {
        invenNum_ = 1;
        slots = slotHolder.GetComponentsInChildren<Slot_Kim>();

        inven.onSlotCountChange += SlotChange;
        inventoryPanel.SetActive(activeInven);
        SlotChange(inven.SlotCnt);
        prevButton.interactable = false;
        Debug.Log(inven.SlotCnt);

        for(int i = 0; i < inven.SlotCnt; i ++)
        {

        }

        if (inven.SlotCnt > 8)
        {
            nextButton.interactable = true;
        }

        for (int i = 8; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInven = !activeInven;
            inventoryPanel.SetActive(activeInven);
        }
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inven.SlotCnt)
            {
                //Debug.Log(slots[i]);
                slots[i].gameObject.SetActive(true);
                
            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }

    public void NextInven()
    {
        invenNum += 1;
    }

    public void PrevInven()
    {
        invenNum -= 1;
    }

    public void FreshSlot(Items_Kim item)
    {
        int i = 0;
        for(; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].count++;
                slots[i].item = item;
                return;
            }
            else if (slots[i].item.itemCode == item.itemCode && slots[i].item.stackAble && slots[i].item.fullQuantity <= slots[i].count)
            {
                slots[i].count ++;
                slots[i].text.text = slots[i].count.ToString();
                return;
            }
        }
    }    

    public void ChangePage()
    {
        if (invenNum == 1)
        {
            prevButton.interactable = false;
            if (inven.SlotCnt > 8)
            {
                nextButton.interactable = true;
                for(int i = 0; i < 8; i++)
                {
                    slots[i].gameObject.SetActive(true);
                }
                for(int i = 8; i < slots.Length; i++)
                {
                    slots[i].gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < inven.SlotCnt; i++)
                {
                    slots[i].gameObject.SetActive(true);
                }
            }
        }
        else if (invenNum != 1)
        {
            for (int i = 1; i < Mathf.CeilToInt((float)inven.SlotCnt / 8); i++)
            {
                Debug.Log("2, " + (Mathf.CeilToInt((float)inven.SlotCnt / 8)));
                Debug.Log(i);
                Debug.Log(invenNum);
                prevButton.interactable = true;
                nextButton.interactable = true;
                if (invenNum == i)
                {
                    Debug.Log((i - 1) * 8);
                    for (int j = i * 8; j < slots.Length; j++)
                    {
                        Debug.Log("1끄기, " + j);
                        slots[j].gameObject.SetActive(false);
                    }
                    for (int j = (i - 1) * 8; j >= 0; j--)
                    {
                        Debug.Log("2끄기, " + j);
                        slots[j].gameObject.SetActive(false);
                    }

                    for (int j = (i - 1) * 8; j < (i) * 8; j++)
                    {
                        Debug.Log("키기, " + j);
                        slots[j].gameObject.SetActive(true);
                    }
                    return;
                }
            }
            if (invenNum == Mathf.CeilToInt((float)inven.SlotCnt / 8))
            {
                Debug.Log("3, " + (Mathf.CeilToInt((float)inven.SlotCnt / 8)));
                Debug.Log((invenNum - 1) * 8);
                prevButton.interactable = true;
                nextButton.interactable = false;
                for (int i = ((invenNum - 1) * 8); i >= 0; i--)
                {
                    Debug.Log("3끄기, " + i);
                    slots[i].gameObject.SetActive(false);
                }
                for (int i = ((invenNum - 1) * 8); i < inven.SlotCnt; i++)
                {
                    slots[i].gameObject.SetActive(true);
                }
            }
        }
    }

    public void AddSlot()           // 인벤 슬롯을 늘리는거(1칸씩)
    {
        inven.SlotCnt++;
    }
}
