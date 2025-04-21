using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDiscordRPC : MonoBehaviour
{
    public DiscordRPCManager discord;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InGame()
    {
        discord.details = "Surviving the Factory";
    }
}
