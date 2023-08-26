using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DelayMethod), 16.5f);
    }

    void DelayMethod()
    {
        Debug.Log("Delay call");
        transform.Rotate(-90, 0, 0, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
