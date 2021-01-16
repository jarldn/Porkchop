using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void doquit()
    {
        Debug.Log("has quit");
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
        
    }

