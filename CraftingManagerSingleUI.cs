
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class CraftingManagerSingleUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    public void SetRecipeSO(BushCraftRecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.CraftedItems;

        foreach(Transform child in iconContainer)
        {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(BushCraftItemSO item in recipeSO.bushCraftItemsSO)
        {
            Transform iconGameObject = Instantiate(iconTemplate, iconContainer);
            iconGameObject.gameObject.SetActive(true);
            iconGameObject.GetComponent<Image>().sprite = item.sprite;
        }
    }
}
