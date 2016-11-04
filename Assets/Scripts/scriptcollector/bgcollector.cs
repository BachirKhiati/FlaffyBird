using UnityEngine;
using System.Collections;

public class bgcollector : MonoBehaviour {
    private GameObject[] backgrounds;
    private GameObject[] grounds;

    private float lastbgx;
    private float lastgoundx;
	// Use this for initialization
	void Awake () {

        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds = GameObject.FindGameObjectsWithTag("Ground");

        lastbgx = backgrounds[0].transform.position.x;
        lastgoundx = grounds[0].transform.position.x;

        for (int i=1; i > backgrounds.Length; i++)
        {
            if (lastbgx < backgrounds[i].transform.position.x)
            {
                lastbgx = backgrounds[i].transform.position.x;
            }
        }
        for (int i = 1; i> grounds.Length; i++)
        {
            if (lastgoundx <grounds[i].transform.position.x)
            {
                lastgoundx = grounds[i].transform.position.x;
            }
        }
    }
	
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag =="Background")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;
            temp.x = lastbgx + width;
            target.transform.position = temp;
            lastbgx = temp.x;
        }
        else if (target.tag == "Ground")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;
            temp.x = lastgoundx + width;
            target.transform.position = temp;
            lastgoundx = temp.x;
        }
    }
}
