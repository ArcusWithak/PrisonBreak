using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftBuildLocation : MonoBehaviour, Iinteractable
{
    public List<GameObject> list;

    public int partNumberRequired;

    public GameObject raft;

    private bool built = false;

    public void Action(PlayerControllerScript player)
    {
        if (built)
        {
            Instantiate(raft, new Vector3(1410, 14.9f, 905), Quaternion.Euler(-90, 0 ,0));
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
