using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void fadeToScene(int sceneIndex)
    {
        levelToLoad = sceneIndex;
        animator.SetTrigger("Fade");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }


}
