using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Kim : MonoBehaviour
{
    [SerializeField]
    Image image;

    public TMP_Text text;

    public int count;

    private Items_Kim _item;
    public Items_Kim item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                if (count == 0)
                {
                    image.sprite = item.itemImage;
                }

                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
                text.text = count.ToString();
            }
            else
            {
                text.text = "";
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
