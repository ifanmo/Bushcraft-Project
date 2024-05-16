using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player.Instance.OnPlayerPickedUpItem += Instance_OnPlayerPickedUpItem;
        Player.Instance.OnPlayerAlreadyHasItem += Instance_OnPlayerAlreadyHasItem;
        CraftingManager.Instance.OnBushcraftItemSuccess += Instance_OnBushcraftItemSuccess;
        CraftingManager.Instance.OnBushcraftItemFailed += Instance_OnBushcraftItemFailed;
    }

    private void Instance_OnPlayerPickedUpItem(object sender, System.EventArgs e)
    {
        audioSource.clip = audioClip[0];
        audioSource.Play();
    }
    
    private void Instance_OnPlayerAlreadyHasItem(object sender, System.EventArgs e)
    {
        audioSource.clip = audioClip[1];
        audioSource.Play();
    }

    private void Instance_OnBushcraftItemSuccess(object sender, System.EventArgs e)
    {
        audioSource.clip = audioClip[2];
        audioSource.Play();
    }

    private void Instance_OnBushcraftItemFailed(object sender, System.EventArgs e)
    {
        audioSource.clip = audioClip[3];
        audioSource.Play();
    }


}
