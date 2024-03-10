using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SceneManagerEx sceneManagerEx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        else
            Destroy(gameObject);
    }

    private void Start()
    {
        sceneManagerEx = GetComponent<SceneManagerEx>();
    }
}
