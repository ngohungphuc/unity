using System.Collections;
using UnityEngine;

public static class CustomCoroutine
{
    public static IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;

        while(Time.realtimeSinceStartup < (start + time))
        {
            yield return null;
        }
    }
}
