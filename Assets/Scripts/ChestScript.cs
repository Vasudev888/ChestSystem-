using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    public float milliSecondToWait = 3600000;
    private Button chestButton;
    private ulong lastChestOpen;
    private Text chestTimer;

    private void Start()
    {
        chestButton = GetComponent<Button>();
        lastChestOpen =  ulong.Parse(PlayerPrefs.GetString("LastChestOpen"));
        chestTimer = GetComponentInChildren<Text>();

        if (!IsChestReady())
        {
            chestButton.interactable = false;
        }
    }

    private void Update()
    {
        if (!chestButton.IsInteractable())
        {
            if (IsChestReady())
            {
                chestButton.interactable = true;
                
                return;
            }

            //set the timer
            ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float secondsLeft = (float)(milliSecondToWait - m) / 1000.0f;

            string r = " ";
            //hours
            r += ((int)secondsLeft / 3600).ToString() + "h ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;
            //minutes
            r += ((int)secondsLeft / 60).ToString("00") + "m ";
            //seconds
            r += (secondsLeft % 60).ToString("00") + "s";
            chestTimer.text = r;
        }
    }

    public void ChestClick()
    {
        lastChestOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastChestOpen", lastChestOpen.ToString());
        chestButton.interactable = false;

        // reward logic
    }

    private bool IsChestReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsLeft = (float)(milliSecondToWait - m) / 1000.0f;

        Debug.Log(secondsLeft);

        if (secondsLeft < 0)
        {
            /*chestButton.interactable = true;
            return;*/
            chestTimer.text = "Ready!";
            return true;

        }

        else
        {
            return false;
        }
    }
}
