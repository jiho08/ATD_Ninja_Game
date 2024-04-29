using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResourceManager.instance.SetRsc(5);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ResourceManager.instance.ResetRsc();
        }
    }
}
