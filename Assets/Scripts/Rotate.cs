using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 1;

    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject TargetObject;

    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0, RotateSpeed, 0));
        if (TargetObject == null) return;

        // 指定オブジェクトを中心に回転する
        this.transform.RotateAround(
            TargetObject.transform.position,
            RotateAxis,
            RotateSpeed
            );
    }
}
