using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;



public class mc : MonoBehaviour
{
    public static mc instance;
    private const string ID = "CgkI39mg3fgUEAIQBg";
    

    [SerializeField]
    public GameObject[] birds;
    public bool isyellowu, isredu;
    private void Awake()
    {
        MakeInstance();


        Time.timeScale = 1f;

    }

    void Start()
    {
        birds[gc.instance.Getselectedbird()].SetActive(true);
        checkifbirdareunlocked();
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            //.RequestEmail()
            //.RequestIdToken()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        if (!Social.localUser.authenticated)
            Social.localUser.Authenticate((bool success) =>
            {
                Debug.Log("Process completed successfully!");
            });


    }
    public void  Rateus()
    {
        Application.OpenURL("market://details?id=com.Devlex.flaffybird");
    }

    public void playgame()
    {
        fadescript.instance.fadain("flappy");
    }
    // Update is called once per frame
    public void OpenLeaderBoardScoreUI()
    {
        OpenLeaderBoardScore();
    }
    public void ConnectOnGooglePlayGames()
    {
        ConnectOrDisconnectOnGooglePlayGames();
    }
    public void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public void checkifbirdareunlocked()
    {

        if (gc.instance.Isredbirdunlocked() == 1)
        {
            isredu = true;
        }
        if (gc.instance.Isyellowbirdunlocked() == 1)
        {
            isyellowu = true;
        }
    }
    public void changebird()
    {
        if (gc.instance.Getselectedbird() == 0)
        {
            if (isyellowu)
            {
                birds[0].SetActive(false);
                gc.instance.Setselectedbird(1);
                birds[gc.instance.Getselectedbird()].SetActive(true);

            }
        }
        else if (gc.instance.Getselectedbird() == 1)
        {
            if (isredu)
            {
                birds[1].SetActive(false);
                gc.instance.Setselectedbird(2);
                birds[gc.instance.Getselectedbird()].SetActive(true);
            }
            else
            {
                birds[1].SetActive(false);
                gc.instance.Setselectedbird(0);
                birds[gc.instance.Getselectedbird()].SetActive(true);
            }

        }
        else if (gc.instance.Getselectedbird() == 2)
        {

            birds[2].SetActive(false);
            gc.instance.Setselectedbird(0);
            birds[gc.instance.Getselectedbird()].SetActive(true);
        }


    }
    public void OpenLeaderBoardScore()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(ID);
            

        }
    }
    public void ConnectOrDisconnectOnGooglePlayGames()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.SignOut();
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {

            });
        }
    }
}