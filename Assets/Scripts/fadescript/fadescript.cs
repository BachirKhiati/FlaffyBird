using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class fadescript : MonoBehaviour
{
    public static fadescript instance;

    [SerializeField]
    private GameObject fadeCanvas;
    [SerializeField]
    private Animator fadeanim;


    // Use this for initialization
    private void Awake()
    {
        makesingliton();

    }

    void makesingliton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void fadain(string levelname)
    {
        StartCoroutine(Fadeinanimation(levelname));
    }
    public void fadeout()
    {
        StartCoroutine(Fadeoutanimation());
    }
    IEnumerator Fadeinanimation(string levelname)
    {
        fadeCanvas.SetActive(true);
        fadeanim.Play("fadein");
        yield return StartCoroutine(co.waitforreal(0.7f));
        SceneManager.LoadScene(levelname);
        fadeout();
    }
    IEnumerator Fadeoutanimation()
    {
        fadeanim.Play("fadeout");
        yield return StartCoroutine(co.waitforreal(1f));
        fadeCanvas.SetActive(false);

    }

    //    public void Starti()
    //    {
    //        StartCoroutine(Start());
    //    }

    //     IEnumerator Start()
    //    {
    //        AsyncOperation async = Application.LoadLevelAsync("flappy");
    //        yield return async;
    //        Debug.Log("Loading complete");
    //    }
    //    public void returni()
    //    {
    //        StartCoroutine(Start());
    //    }

    //    IEnumerator Start()
    //    {
    //        AsyncOperation async = Application.LoadLevelAsync("ain");
    //        yield return async;
    //        Debug.Log("Loading complete");
    //    }


}