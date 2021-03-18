using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftBuildLocation : MonoBehaviour, Iinteractable
{
    public List<GameObject> list;
    public void Action(PlayerControllerScript player)
    {
        list = player.AddRaftParts();
    }
}
