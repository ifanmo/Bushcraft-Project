using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BushCraftRecipeSO : ScriptableObject
{
    public List<BushCraftItemSO> bushCraftItemsSO;
    public string CraftedItems;   
}
