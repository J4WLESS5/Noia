using Discord;
using UnityEditor;
using UnityEngine;

public class DiscordRPCManager : MonoBehaviour
{
    // Details about the rich presence
    public string details = "Being A Goofy Little Goober LOL!";
    public string state = "Bruh Moment :p";
    public string largeImageKey = "";  // Must match an asset uploaded in the application!!!
    public string largeImageText = "";  // The text that shows when a user on Discord hovers over the large icon

    private Discord.Discord _client;
    private long _applicationId = 1358581834966892594;  // ID of the Discord Application

    // Start is called before the first frame update
    void Start()
    {
        _client = new Discord.Discord(_applicationId, (System.UInt64) Discord.CreateFlags.Default);
        var activityManager = _client.GetActivityManager();
        var activity = new Discord.Activity()
        {
            Details = details,
            State = state,
            Assets = new Discord.ActivityAssets()
            {
                LargeImage = largeImageKey,
                LargeText = largeImageText
            }
        };
        
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("Discord RPC was setup successfully!");
            }
            else
            {
                Debug.Log("Oh noesies, Discord RPC failed to initialize :(");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        _client.RunCallbacks();  // Make callbacks to Discord
    }

    private void OnApplicationQuit()
    {
        _client.Dispose();
    }
}
