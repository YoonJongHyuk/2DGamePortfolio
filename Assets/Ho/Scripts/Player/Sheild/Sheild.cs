using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheild : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("ActiveFalse", 3);
    }

    public void ActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
