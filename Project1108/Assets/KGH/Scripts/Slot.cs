using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    Image image;

    public TMP_Text text;

    public int count;

    private Items _item;
    public Items item
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
