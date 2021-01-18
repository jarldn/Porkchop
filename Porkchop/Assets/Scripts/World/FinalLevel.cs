using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    LevelChanger levelChanger;
    // Start is called before the first frame update
    void Start()
    {
        levelChanger = GameObject.Find("Level Changer").GetComponent<LevelChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            levelChanger.fadeToScene(3);
        }
    }
}
