using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class gpc : MonoBehaviour {
    
    public static gpc instance;
    [SerializeField]
    private Text scoreText, endScore, bestscore;
    [SerializeField]
    private Button restargamebutton, resumegamebutton, insturctionbutton;
    [SerializeField]
    private GameObject pausepanel;
    [SerializeField]
    private GameObject[] birds;
    [SerializeField]
    private Sprite[] medals;
    [SerializeField]
    private Image medalimage;
    [SerializeField]
    private Image Gameover;
    private float forwardspeed = 3f;
    private float bouncespeed = 4f;
    private Button flapbutton;
    private bool didflap;
    public bool isalive;
    public int score;
    private const string ID = "CgkI39mg3fgUEAIQBg";
    // Use this for initialization
    void Awake () {
        makeinstance();
        

    }
    void Start()
    {
        Time.timeScale = 0f;
        

    }
   
    

    // Update is called once per frame
    void makeinstance() {
	    if (instance!=null)
	    {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
	}
    public void pausegame()
     {
        if (Birdflap.instance!=null)
        {
            if (Birdflap.instance.isalive)
            {
                pausepanel.SetActive(true);
                Gameover.gameObject.SetActive(false);
                endScore.text = "" + Birdflap.instance.score;
                bestscore.text = "" + gc.instance.Gethighscore();
                Time.timeScale = 0f;
                restargamebutton.gameObject.SetActive(false);
                resumegamebutton.gameObject.SetActive(true);

            }
        }
        }
     public void gotomenubutton()
    {
        fadescript.instance.fadain("main");
    }
         public void resumegame()
     {
        pausepanel.SetActive(false);
        Time.timeScale = 1f;
        
        }
         public void restartgame()
     {
        Destroy(GameObject.Find("gpc"));
        SceneManager.LoadScene("flappy");
    }
         public void playgame()
     {
        scoreText.gameObject.SetActive(true);
        birds [gc.instance.Getselectedbird()].SetActive(true);
        insturctionbutton.gameObject.SetActive(false);
        Time.timeScale = 1f;

        }
         public void setscore( int score)
     {
        scoreText.text = "" + score;
        }
    public void playerdiedshowscore(int score)
    {
        
        pausepanel.SetActive(true);
        restargamebutton.gameObject.SetActive(true);
        resumegamebutton.gameObject.SetActive(false);
        Gameover.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);

        endScore.text = "" + scoreText.text;

        if (score > gc.instance.Gethighscore())
        {
            gc.instance.Sethighscores(score);
        }
        bestscore.text = "" + gc.instance.Gethighscore();
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, ID, (bool success) =>
            {

            });
        }
        if (score <= 20)
        {
            medalimage.sprite = medals[1];
        }
        else if (score > 20 || score < 41)
        {
            medalimage.sprite = medals[0];
            if (gc.instance.Isyellowbirdunlocked() == 0)
            {
                gc.instance.Unlockredbird();
            }
        }

        else
        {
            medalimage.sprite = medals[2];
       
        if (gc.instance.Isyellowbirdunlocked() == 0)
        {
            gc.instance.Unlockredbird();
        }
        if (gc.instance.Isredbirdunlocked() == 0)
        {
            gc.instance.Unlockredbird();
        }
    }
       
        
    }
 




}
