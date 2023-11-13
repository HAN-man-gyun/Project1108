using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;

    public Item _item;

    public int count = 0;

    public string names;

    public TMP_Text text;


    private void Update()
    {
        if(count >= 1 && (_item != null))
        {
            text.text = count.ToString();
        }
        else if(_item == null || count <= 0)
        {
            text.text = "";
        }
        else
        {
            text.text = "";
        }
    }
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                //Debug.Log(item.itemImage);
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
                names = item.itemName;
            }
            else if(count <= 0)
            {
                Debug.Log("asd");
                image.color = new Color(1, 1, 1, 0);
            } 
            else
            {
                Debug.Log("asd");
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
