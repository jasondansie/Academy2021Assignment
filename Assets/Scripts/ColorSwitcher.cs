using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
