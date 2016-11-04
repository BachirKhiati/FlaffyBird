using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayLogin : MonoBehaviour
{

    void Awake()
    {
        Social.localUser.Authenticate((bool success) => {


            if (success)
            {
                PlayGamesPlatform.Activate();
            }

        });
    }
}