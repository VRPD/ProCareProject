using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    public GameObject player;
    public GameObject node;



    public void teleportPlayer()
    {
        player.transform.position = node.transform.position;
    }
}
