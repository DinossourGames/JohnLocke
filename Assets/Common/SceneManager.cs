using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
//    [SerializeField] Sprite[] BgImages = default;
//    [SerializeField] Image Background = default;
//    [SerializeField] Image LoadingBar = default;

//    public static string sceneToLoad;
//    public static int index;
//    

//    private void Start()
//    {
//        if (sceneToLoad != null && index <= BgImages.Length)
//        {
//            StartCoroutine(LoadSceneAsync(sceneToLoad, index));
//        }
//    }

    public static void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene()
            .buildIndex);
    }
    
    public static void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    
    public void LoadSceneNormal(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void Sair()
    {
        Application.Quit();
    }
    
//    public static void LoadScene(string sceneName, int bgIndex)
//    {
//        sceneToLoad = sceneName;
//        index = bgIndex;
//        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("LoadingScreen");
//    }
//
//    IEnumerator LoadSceneAsync(string sceneName, int bgIndex)
//    {
//        Background.sprite = BgImages[bgIndex];
//
//        float duration = 5f;
//
//        float totalTime = 0;
//        while (totalTime <= duration)
//        {
//            LoadingBar.fillAmount = totalTime / duration;
//            totalTime += Time.deltaTime;
//            yield return null;
//        }
//
//        yield return new WaitForSeconds(.7f);
//
//        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
//    }
    
 }