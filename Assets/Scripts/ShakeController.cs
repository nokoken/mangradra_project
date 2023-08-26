using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeController : MonoBehaviour
{
    // 揺らすためのパラメータが格納された構造体ShakeInfo
    private struct ShakeInfo
    {
        public ShakeInfo(float duration, float strength, float vibrato){
            Duration = duration;
            Strength = strength;
            Vibrato = vibrato;
        }
        public float Duration {get;}
        public float Strength {get;}
        public float Vibrato {get;}
    }

    // メンバ変数
    private ShakeInfo _shakeInfo;
    private Vector3 _Init_Position;
    private bool _IsDoShake;
    private float _TotalShakeTime;
    // 揺れる時間
    [SerializeField] float _duration;
    // 力
    [SerializeField] float _strength;
    // 揺れる距離
    [SerializeField] float _vibrato;


    // Start is called before the first frame update
    private void Start()
    {
        _Init_Position = gameObject.transform.position;

        StartShake(_duration, _strength, _vibrato);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_IsDoShake) return;
        gameObject.transform.position = UpdateShakePosition(
            gameObject.transform.position, 
            _shakeInfo,
            _TotalShakeTime,
            _Init_Position);
        _TotalShakeTime += Time.deltaTime;
        if (_TotalShakeTime >= _shakeInfo.Duration){
            _IsDoShake = false;
            _TotalShakeTime = 0.0f;
            gameObject.transform.position = _Init_Position;
        }
    }

    // 揺らす際のベクトル計算をする関数UpdateShakePosition
    private Vector3 UpdateShakePosition(Vector3 currentPosition, ShakeInfo shakeInfo, float totalTime, Vector3 initPosition){
        var strength = shakeInfo.Strength;
        var randomY = Random.Range(-10.0f * strength, strength);
        var position = currentPosition;
        position.y += randomY;
        var vibrato = shakeInfo.Vibrato;
        var ratio = 1.0f - totalTime / shakeInfo.Duration;
        vibrato *= ratio;
        position.y = Mathf.Clamp(position.y, initPosition.y - vibrato, initPosition.y + vibrato);
        return position;
    }

    // それぞれのメンバの初期化をする関数StartShake
    public void StartShake(float duration, float strength, float vibrato){
        _shakeInfo = new ShakeInfo(duration, strength, vibrato);
        _IsDoShake = true;
        _TotalShakeTime = 0.0f;
    }
}