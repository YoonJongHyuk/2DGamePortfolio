using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : MonoBehaviour
{
    public enum SceneName
    {
        TestLoading,
        FirstScene,
        MainScene,
    }

    private static SceneManagerEx instance;

    public static SceneManagerEx Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("SceneManagerEx");
                instance = go.AddComponent<SceneManagerEx>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static SceneName sceneToLoad;

    public static void LoadScene(SceneName sceneName)
    {
        sceneToLoad = sceneName;
        SceneManager.LoadScene(SceneName.TestLoading.ToString()); // 여기에서 수정되어야 합니다.
    }
}
