using UnityEngine;
using System.Collections;

public class pipecollector : MonoBehaviour {
    private GameObject[] pipeholders;
    private float distance = 3.5f;
    private float lastpipex;
    private float lastpipey;
    private float pipemax = 1.8f;
    private float pipemin= -1.2f;
	// Use this for initialization
	void Awake () {
        pipeholders = GameObject.FindGameObjectsWithTag("PipeHolder");
        for (int i=0;i<pipeholders.Length;i++)
        {
            Vector3 temp = pipeholders[i].transform.position;
            temp.y = Random.Range(pipemin, pipemax);
         pipeholders[i].transform.position = temp;
            
            
        }
        lastpipex = pipeholders[0].transform.position.x;

        for (int i=0;i < pipeholders.Length;i++)
        {
            if (lastpipex< pipeholders[i].transform.position.x)
            {
                lastpipex = pipeholders[i].transform.position.x;
            }
        }

        

    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            Vector3 temp = target.transform.position;
            temp.x = lastpipex + distance;
            temp.y = Random.Range(pipemin, pipemax);
            target.transform.position = temp;
            lastpipex = temp.x;
        }
    }
}
