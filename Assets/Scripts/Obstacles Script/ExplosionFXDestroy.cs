using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFXDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisableGameObject", 3f);
    }

    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
