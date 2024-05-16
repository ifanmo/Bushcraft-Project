using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManagerUI : MonoBehaviour
{

    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;
    // Start is called before the first frame update
    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CraftingManager.Instance.OnRecipeSpawned += Instance_OnRecipeSpawned;
        CraftingManager.Instance.OnRecipeCompleted += Instance_OnRecipeCompleted;

        UpdateVisual();
    }

    private void Instance_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void Instance_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach(Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(BushCraftRecipeSO bushCraftItemSO in CraftingManager.Instance.GetItemsToCraft())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<CraftingManagerSingleUI>().SetRecipeSO(bushCraftItemSO);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
