using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private float fakeLoadDelay = 2f;

   void Start() 
    {
        StartCoroutine(LoadMainSceneAsync());
    }


   IEnumerator LoadMainSceneAsync() 
    {
        yield return new WaitForSeconds(fakeLoadDelay);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Demo");
        operation.allowSceneActivation = false;

        while (!operation.isDone) 
        { 
            float progress=Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;

            if (operation.progress >= 0.9f) 
            {
                operation.allowSceneActivation = true;
            }
       
            yield return null;
        }
    }
}
