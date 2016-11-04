using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour
{
    private GameObject[] cloudholders;
    private float clouddistance = 3.5f;
    private float lastcloudx;
    private float lastcloudy;
    private float cloudmax = 6f;
    private float cloudmin = -0.5f;
    // Use this for initialization
    void Awake()
    {
        cloudholders = GameObject.FindGameObjectsWithTag("clouds");
        for (int i = 0; i < cloudholders.Length; i++)
        {
            Vector3 temp = cloudholders[i].transform.position;
            temp.y = Random.Range(cloudmin, cloudmax);
            cloudholders[i].transform.position = temp;


        }
        lastcloudx = cloudholders[0].transform.position.x;

        for (int i = 0; i < cloudholders.Length; i++)
        {
            if (lastcloudx < cloudholders[i].transform.position.x)
            {
                lastcloudx = cloudholders[i].transform.position.x;
            }
        }



    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == ("clouds"))
        {
            Vector3 temp = target.transform.position;
            temp.x = lastcloudx + clouddistance;
            temp.y = Random.Range(cloudmin, cloudmax);
            target.transform.position = temp;
            lastcloudx = temp.x;
        }
    }
}
