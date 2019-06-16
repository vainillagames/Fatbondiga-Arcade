using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    private void Start()
    {
        Invoke("Delay", 1.5f);
        
    }
    private void Delay()
    {
        LoadLevel(4);
    }
    public void LoadLevel(int sceneIndex)
    {

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }
}
