using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandeler : MonoBehaviour
{

    protected void LoadNewScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (currentSceneIndex)
        {
            case 0:
                StartCoroutine(SceneProgress(1, currentSceneIndex));
                break;
            case 1:
                StartCoroutine(SceneProgress(0, currentSceneIndex));
                break;
        }
    }

    private IEnumerator SceneProgress(int buildIndex, int currentSceneIndex)
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        yield return new WaitUntil(() => loadingScene.isDone == true);
        SceneManager.UnloadSceneAsync(currentSceneIndex);
    }
}
