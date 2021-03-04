using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class MonsterBook : MonoBehaviour, Iinteractable
{
    public void action(PlayerControllerScript player)
    {
        StartCoroutine(CallApi(player));
    }

    public IEnumerator CallApi(PlayerControllerScript player)
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
                string message = "";
                JSONNode monsterInfo = JSON.Parse(www.downloadHandler.text);

                switch (Random.Range(0, 4))
                {
                    case 0:
                        message = $"has {monsterInfo["hit_points"].Value} hp, what ever that means";
                        break;
                    case 1:
                        message = $"has a armor class of {monsterInfo["armor_class"].Value}, what is a armor class?";
                        break;
                    case 2:
                        message = $"is a part of the {monsterInfo["type"].Value} species, kinda obviuos if you ask me";
                        break;
                    case 3:
                        message = $"can move up too {monsterInfo["speed"]["walk"].Value} in 6 seconds, which is oddly specific";
                        break;
                }

                player.GiveFeedBack($"it says here that a {monsterInfo["name"].Value} {message}");
            }
        }
    }
}
