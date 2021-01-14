using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HeartSystem : MonoBehaviour
{

    public GameObject[] hearts;
    public int vidas;

    // Update is called once per frame
    void Update()
    {
        if (vidas < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if (vidas < 2)
        {
            Destroy(hearts[1].gameObject);
        } 
        else if (vidas < 3)
        {
            Destroy(hearts[1].gameObject);
        }
    }

    public void fakeDamage(int d)
    {
        vidas -= d;
    }
}
