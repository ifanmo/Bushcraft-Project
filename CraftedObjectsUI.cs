using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftedObjectsUI : MonoBehaviour
{
    [SerializeField] private GameObject[] craftItemsUI;
    // Start is called before the first frame update
    void Start()
    {
        CraftingManager.Instance.OnBushcraftItemSuccess += Instance_OnBushcraftItemSuccess;
        CraftingManager.Instance.OnBushcraftItemFailed += Instance_OnBushcraftItemFailed;
        
        foreach (var craftItem in craftItemsUI) {
            craftItem.SetActive(false);

        }
        
    }

    private void Instance_OnBushcraftItemFailed(object sender, System.EventArgs e)
    {
        Show(craftItemsUI[5]);

        HideAfterDelay(craftItemsUI[5]);
    }
    
    private void Instance_OnBushcraftItemSuccess(object sender, CraftingManager.OnBushcraftItemSuccessEventArgs e)
    {
        if(e.bushCraftRecipeSO.CraftedItems == "Tent")
        {
            Show(craftItemsUI[0]);

            HideAfterDelay(craftItemsUI[0]);

        } else if (e.bushCraftRecipeSO.CraftedItems == "Fire")
        {
            Show(craftItemsUI[1]);

            HideAfterDelay(craftItemsUI[1]);


        } else if(e.bushCraftRecipeSO.CraftedItems == "Fishing Rod")
        {
            Show(craftItemsUI[2]);

            HideAfterDelay(craftItemsUI[2]);


        } else if(e.bushCraftRecipeSO.CraftedItems == "Torch")
        {
            Show(craftItemsUI[3]);

            HideAfterDelay(craftItemsUI[3]);


        }
        else if (e.bushCraftRecipeSO.CraftedItems == "Stone Hammer")
        {
            Show(craftItemsUI[4]);

            HideAfterDelay(craftItemsUI[4]);

        }
    }

    private void Show(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void HideAfterDelay(GameObject gameObject)
    {
        StartCoroutine(RemoveAfterSeconds(4));

        IEnumerator RemoveAfterSeconds(int seconds)
        {
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }
    }
   
}
