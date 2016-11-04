using UnityEngine;
using System.Collections;

public class gc : MonoBehaviour {

    public static gc instance;
    public const string HIGH_SCORE = "High Score";
    public const string SELECTED_BIRD = "Selected Bird";
    public const string YELLOW_BIRD = "Yellow Bird";
    public const string RED_BIRD = "Red Bird";

    public void Awake()
    {
        MakeSingleton();
        IsTheGameStaredForTheFirstTime();
        PlayerPrefs.DeleteAll();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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

    public void  IsTheGameStaredForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsTheGameStaredForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(SELECTED_BIRD, 0);
            PlayerPrefs.SetInt(YELLOW_BIRD, 0);
            PlayerPrefs.SetInt(RED_BIRD, 0);
            PlayerPrefs.SetInt("IsTheGameStaredForTheFirstTime", 0);
        }
       
      
    }

    public void Sethighscores(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int Gethighscore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);

    }

    public void Setselectedbird(int selectedbird)
    {
        PlayerPrefs.SetInt(SELECTED_BIRD, selectedbird);
    }
    public int Getselectedbird()
    {
        return PlayerPrefs.GetInt(SELECTED_BIRD);
    }
   
    public void Unlockredbird()
    {
        PlayerPrefs.SetInt(RED_BIRD, 1);
    }
    public int Isredbirdunlocked()
    {
        return PlayerPrefs.GetInt(RED_BIRD);
    }
    public void Unlockyellowbird()
    {
        PlayerPrefs.SetInt(YELLOW_BIRD, 1);
    }
    public int Isyellowbirdunlocked()
    {
        return PlayerPrefs.GetInt(YELLOW_BIRD);
    }
}
