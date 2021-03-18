using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftBuildLocation : MonoBehaviour, Iinteractable
{
    public List<GameObject> list;

    public int partNumberRequired;

    private bool built = false;

    public void Action(PlayerControllerScript player)
    {
        if (built)
        {
            //TODO: do stuff
        }
        else
        {
            list = player.AddRaftParts();

            if(list.Count >= partNumberRequired)
            {
                built = true;
            }
        }
    }
}
