using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public itemProperty item;
    public Image img;
    public Image amountbg;
    public Text amoutText;

    public void setItem(itemProperty item)
    {
        this.item = item;
        if (item == null)
        {
            img.enabled = false;
            amoutText.enabled = false;
            amountbg.enabled = false;

            gameObject.name = "Empty";
        }
        else {

            img.enabled = true;
            amountbg.enabled = true;
            amoutText.enabled = true;
            gameObject.name = item.name;
            img.sprite = item.sprite;
        }

    }
}
