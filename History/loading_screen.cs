using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading_screen : MonoBehaviour
{
    public GameObject canvas;
    public Slider fill;


    public void Loadlevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
       
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);
        canvas.SetActive(true);
        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress/.9f);
            fill.value = progress;
            yield return null;
        }
    }
    

}
