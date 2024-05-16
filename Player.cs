using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public static Player Instance { get; private set; }
    // Update is called once per frame
    public event EventHandler OnPlayerPickedUpItem;
    public event EventHandler OnPlayerAlreadyHasItem;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        PlayerPicksUpItem();
        
    }

    private void PlayerPicksUpItem()
    {
        // Get touch input from the users mobile device
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            
            // If there is a raycast hit
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.transform.TryGetComponent(out BushcraftItem bushcraftItem))
                {
                    BushCraftItemSO bushcrafItemSO = bushcraftItem.GetBushCraftItemSO();
                    AddBushCraftItem(bushcrafItemSO);

                }
            }
        }
    }

    private void AddBushCraftItem(BushCraftItemSO bushcraftItemSO)
    {
        if(!(Inventory.Instance.hasItem(bushcraftItemSO))) 
        {
            OnPlayerPickedUpItem?.Invoke(this, EventArgs.Empty);
            Inventory.Instance.AddItem(bushcraftItemSO);
        } else
        {
            OnPlayerAlreadyHasItem?.Invoke(this, EventArgs.Empty);
        }
    }

    
}
