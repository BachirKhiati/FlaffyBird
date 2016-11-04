using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Birdflap : MonoBehaviour {
    public static Birdflap instance;
    [SerializeField]
    private Rigidbody2D myrigidbody;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flapClik, poitClip, diedclip;

    private float forwardspeed= 2f;
    private float bouncespeed= 3.5f;
    private Button flapbutton;
    private bool didflap;
    public bool isalive;
    public int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        isalive = true;
        flapbutton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        flapbutton.onClick.AddListener(() => flapthebird());
        setcamerax();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if (isalive)
	{
            Vector3 temp = transform.position;
            temp.x += forwardspeed * Time.deltaTime;
            transform.position = temp;
            if (didflap)
            {
                didflap = false;
                myrigidbody.velocity = new Vector2(0, bouncespeed);
               
                 audioSource.PlayOneShot(flapClik);
                anim.SetTrigger("flap");
            }
            if(myrigidbody.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -60, -myrigidbody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
	}
	}

    public void setcamerax()
    {
        Camerascript.offsetx = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public void flapthebird()
    {
        didflap = true;
    }
    public float GetPositionX()
    {
        return transform.position.x;
    }
     void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag=="Ground" || target.gameObject.tag=="Pipe")
        {
            if (isalive)
            {
                isalive = false;
                anim.SetTrigger("die");
                audioSource.PlayOneShot(diedclip);
                gpc.instance.playerdiedshowscore(score);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "PipeHolder")
        {
            if (isalive)
            {
                score++;
                gpc.instance.setscore(score);
                audioSource.PlayOneShot(poitClip);
            }
        }
    }
}
