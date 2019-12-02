using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int itemCount;
    public Image itemImage;

    [SerializeField]
    private Text text_count;
    [SerializeField]
    private GameObject go_CountImage;
    // Start is called before the first frame update

    public void AddItem(GameObject _item, int _count = 1) {
        item = _item;
        itemCount = _count;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
