using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    [SerializeField] 
    public Image image;

    public Item _item;

    public int _count = 0;

    public string names;

    public TMP_Text text;

    public Image _image;
    private void Start()
    {
        _image = image;
    }
    private void Update()
    {
        if(_count >= 1 && (_item != null))
        {
            text.text = _count.ToString();
        }
        else if(_item == null || _count <= 0)
        {
            text.text = "";
        }
        else
        {
            text.text = "";
        }
    }

    public void Restart()
    {
        _item = null;
        _count = 0;
        image.sprite = _image.sprite;
        name = null;

    }
    public int count
    {
        get { return _count; }
        set
        {
            _count = value;
        }
    }
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null && count >= 0)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
                names = item.itemName;
            }
            else if(count <= 0)
            {
                image.color = new Color(1, 1, 1, 0);
            } 
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

  
}
