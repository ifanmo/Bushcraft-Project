using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    [SerializeField] private GameObject iconContainer;
    private GameObject[] icons;

    public List<BushCraftItemSO> itemList = new List<BushCraftItemSO>();


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        icons = new GameObject[iconContainer.transform.childCount];

        for(int i = 0; i < iconContainer.transform.childCount; i++)
        {
            icons[i] = iconContainer.transform.GetChild(i).gameObject;
        }

        UpdateVisual();
    }


    public void UpdateVisual()
    {
        for(int i = 0; i < icons.Length - 1; i++)
        {
            icons[i].transform.GetChild(0).GetComponent<Image>().sprite = itemList[i].sprite;
        }
    }
    
    public void AddItem(BushCraftItemSO item)
    {
        itemList.Add(item);
        UpdateVisual();
    }

    public List<BushCraftItemSO> GetItemList()
    {
        return itemList;
    }

    public void ClearItemList()
    {
        itemList.Clear();
        for(int i = 0; i < icons.Length - 1; i++)
        {
            icons[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
        }
    } 

    public bool hasItem(BushCraftItemSO bushCraftItemSO)
    {
        return itemList.Contains(bushCraftItemSO);
    }

    public List<BushCraftItemSO> getBushCraftItemList()
    {
        return itemList;
    }
}
