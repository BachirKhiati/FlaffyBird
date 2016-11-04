using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class leadeboard : MonoBehaviour
{
    public static leadeboard instance;
    private const string ID = "CgkI39mg3fgUEAIQBg";
    private Button Leaderboardbutton;
    // Use this for initialization
    private void Awake()
    {
        MakeSingleton();

    }
    void Start()
    {
        PlayGamesPlatform.Activate();
    
       
    }
    

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

   
    }
   
   
    
