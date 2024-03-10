using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManagerEx.LoadScene(SceneManagerEx.SceneName.MainScene); // ������ �κ�
    }

    public void LoadFirstScene()
    {
        SceneManagerEx.LoadScene(SceneManagerEx.SceneName.FirstScene); // ������ �κ�
    }

    public void LoadLobbyScene()
    {
        SceneManagerEx.LoadScene(SceneManagerEx.SceneName.TestLoading);
    }
}
