﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class FinalDoorLock : SceneHandeler, Iinteractable
{
    private string awnser;
    private string riddle;
    private bool unlocked;

    private Coroutine doorCheckInProgress;

    private void Start()
    {
        StartCoroutine(CallApi());
    }

    public void action(PlayerControllerScript player)
    {
        if (!unlocked)
        {
            player.OpenRiddle(riddle, awnser);

            if (doorCheckInProgress != null)
            {
                StopCoroutine(doorCheckInProgress);
            }

            StartCoroutine(DoorCheck(player));
        }
        else
        {
            LoadNewScene();
        }
    }

    private IEnumerator DoorCheck(PlayerControllerScript player)
    {
        yield return new WaitUntil(() => player.riddleAwnsered == true);

        player.riddleAwnsered = false;

        if (player.CheckRiddle())
        {
            OpenDoor();
            player.CloseRiddle();
        }
    }

    public void OpenDoor()
    {
        unlocked = true;

        LoadNewScene();
    }

    public IEnumerator CallApi()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://www.dnd5eapi.co/api/monsters/adult-black-dragon/"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                JSONNode monsterInfo = JSON.Parse(www.downloadHandler.text);

                switch (Random.Range(0, 4))
                {
                    case 0:
                        awnser = monsterInfo["hit_points"].Value;
                        riddle = $"how much hp does a {monsterInfo["name"]} have?";
                        break;
                    case 1:
                        awnser = monsterInfo["armor_class"].Value;
                        riddle = $"what is the armor class of a {monsterInfo["name"]}?";
                        break;
                    case 2:
                        awnser = monsterInfo["type"].Value;
                        riddle = $"what is the species of a {monsterInfo["name"]}";
                        break;
                    case 3:
                        awnser = monsterInfo["speed"]["walk"].Value;
                        riddle = $"how fast can a {monsterInfo["name"]} move within in 6 seconds";
                        break;
                }
            }
        }
    }
}
