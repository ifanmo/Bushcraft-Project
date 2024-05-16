using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushcraftItem : MonoBehaviour
{
    [SerializeField] private BushCraftItemSO bushcraftItemSO;

    public BushCraftItemSO GetBushCraftItemSO (){
        return bushcraftItemSO; }

    
}
