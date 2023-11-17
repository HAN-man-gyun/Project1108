using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange = delegate { };

    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt; 
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SlotCnt = 20;        // 슬롯 기본갯수
    }
}
