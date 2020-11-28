using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
public Toggle FullscreenToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 public void ApplyFullScreen()
    {
        if(FullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
   
    public void ApplyChanges()
    {

    }

    List<int> widths = new List<int>() { 568, 960, 1280, 1920 };
    List<int> heights = new List<int>() { 320, 540, 800, 1080 };

    public void SetScreenSize (int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }
}



