using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemsButton : MonoBehaviour
{
    public void ClearInventory()
    {
        Inventory.Instance.ClearItemList();
    }
}
