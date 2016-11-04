using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class fading : MonoBehaviour
{
    public static fading instance;
    public Texture2D fadeouttex;
    public float fadespeed = 0.8f;
    public int drawdepth = -1000;
    public float alpha = 1;
    public int fadedir = -1;

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

    public void OnGUI()
    {
        alpha += fadedir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawdepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.height,Screen.width), fadeouttex);

    }

    public float beginfade(int direction)
    {
        fadedir = direction;
        return (fadespeed);
    }
    public void onlevelwasload()
    {
        beginfade(-1);
    }
    public void fadain(string levelname)
    {
        StartCoroutine(fadeanim(levelname));
    }
        IEnumerator fadeanim(string levelname)
    {
        float fadetime = GameObject.Find("fading").GetComponent<fading>().beginfade(1);
        yield return new WaitForSeconds(fadetime);
        SceneManager.LoadScene(levelname);
    }
}