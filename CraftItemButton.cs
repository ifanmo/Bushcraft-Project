using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItemButton : MonoBehaviour
{
    public void CraftItemOnButtonPressed()
    {
        CraftingManager.Instance.CraftItem(Inventory.Instance.getBushCraftItemList());
    }    
}
