using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    private Button chestButton;
    private ulong lastChestOpen;

    private void Start()
    {
        chestButton = GetComponent<Button>();
        lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastChestOpen"));
    }

    private void Update()
    {
        if (!chestButton.IsInteractable())
        {
            ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
            ulong m = diff / TimeSpan.TicksPerMillisecond;

            float secondstoLeft = (float)(3000.0f - m) / 1000.0f;

            if(secondstoLeft < 0)
            {
                chestButton.interactable = true;
                return; 
            }
            Debug.Log(diff);
        }
    }

    public void ChestClick()
    {
        lastChestOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastChestOpen", lastChestOpen.ToString());
        chestButton.interactable = false;
    }

}
