using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    // This class is adapted from Code Monkey Learn Unity Beginner/Intermediate 2023 (FREE COMPLETE Course - Unity Tutorial) on YouTube [Available at: https://www.youtube.com/watch?v=AmGSEH7QcDg&t=10313s] 

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler<OnBushcraftItemSuccessEventArgs> OnBushcraftItemSuccess;
    public event EventHandler OnBushcraftItemFailed;

    public class OnBushcraftItemSuccessEventArgs : EventArgs
    {
        public BushCraftRecipeSO bushCraftRecipeSO;
    }
    
    public static CraftingManager Instance { get; private set; }
    [SerializeField] private List<BushCraftRecipeSO> craftedItems;

    private List<BushCraftRecipeSO> itemsToCraft;
    private float spawnTimer;
    private float spawnTimerMax = 4f;
    private int maxBushcraftRecipes = 1;
    private int score;

    private void Awake()
    {
        Instance = this;
        itemsToCraft = new List<BushCraftRecipeSO>();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            spawnTimer = spawnTimerMax;
             
            if(itemsToCraft.Count < maxBushcraftRecipes ) {
                BushCraftRecipeSO bushcraftRecipeSO = craftedItems[UnityEngine.Random.Range(0, craftedItems.Count)];

                itemsToCraft.Add(bushcraftRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            } 
        }
    }

    public void CraftItem(List<BushCraftItemSO> inventoryList)
    {
        // Go through all the waiting items
        for(int i = 0;i < itemsToCraft.Count; i++)
        {
            BushCraftRecipeSO bushCraftRecipeSO = itemsToCraft[i];
            bool itemsInInventoryMatches = true;
            //Cycling through all the bushcraft items waiting to be crafted
            foreach(BushCraftItemSO itemToCraft in bushCraftRecipeSO.bushCraftItemsSO)
            {
                //Cycle through all items in inventory
                bool itemFound = false;
                foreach(BushCraftItemSO inventoryItem in inventoryList)
                {
                    if(itemToCraft ==  inventoryItem)
                    {
                        itemFound = true; 
                        break;
                    }
                }

                if(!itemFound)
                {
                    // This item was not in the inventory
                    itemsInInventoryMatches = false;
                }
            }

            if(itemsInInventoryMatches)
            {
                //Player crafted the correct ite,
                itemsToCraft.RemoveAt(i);
                OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                OnBushcraftItemSuccess?.Invoke(this, new OnBushcraftItemSuccessEventArgs
                {
                    bushCraftRecipeSO = bushCraftRecipeSO
                });
                
                score += 10;
                Inventory.Instance.ClearItemList();
                return;
            }
        }

        // Incorrect item
        OnBushcraftItemFailed?.Invoke(this, EventArgs.Empty);
        Inventory.Instance.ClearItemList();
    }

    public List<BushCraftRecipeSO> GetItemsToCraft()
    {
        return itemsToCraft;
    }

    public int GetScore()
    {
        return score;
    }
}
