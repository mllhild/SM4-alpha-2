using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM4StartGame : MonoBehaviour
{
    public AsyncOperation asyncLoad;
    
    public void TestStartOfGame()
    {
        // Save SlaveMaker to autosaveslot
        SM4SlaveMakerControler.instance.AutoSaveSave();
        // LoadNextScene
        StartCoroutine(LoadYourAsyncScene("SM4"));
        
    }
    
    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            Debug.Log(asyncLoad.progress.ToString());
            yield return null;
        }
    }
    
    
}
