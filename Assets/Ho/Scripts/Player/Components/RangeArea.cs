using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeArea : MonoBehaviour
{
    BoxCollider2D coll;
    
    
    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    
    public void ActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
