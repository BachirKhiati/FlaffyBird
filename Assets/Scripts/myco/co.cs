using UnityEngine;
using System.Collections;

public static class co   {

    public static IEnumerator waitforreal(float time)
    {
        float start = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup< (start+time))
        {
            yield return null;
        }
    }
}
