using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManagerEx.LoadScene(SceneManagerEx.SceneName.MainScene); // 수정된 부분
    }

    public void LoadFirstScene()
    {
        SceneManagerEx.LoadScene(SceneManagerEx.SceneName.FirstScene); // 수정된 부분
    }

    public void LoadLobbyScene()
    {
        SceneManagerEx.LoadScene(SceneManagerEx.SceneName.TestLoading);
    }
}
