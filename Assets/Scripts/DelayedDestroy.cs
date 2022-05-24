using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{

    [SerializeField]
    float timeToDestory;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyGameObject", timeToDestory);
    }


    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
