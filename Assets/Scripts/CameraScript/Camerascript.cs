using UnityEngine;
using System.Collections;

public class Camerascript : MonoBehaviour {
    public static float offsetx;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	if (Birdflap.instance!=null)
	{
            if(Birdflap.instance.isalive)
            {
                movethecamera();
            }
	}
	}

    void movethecamera()
    {
        Vector3 temp = transform.position;
        temp.x = Birdflap.instance.GetPositionX()+2;
        transform.position = temp;
    }
}
