using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Runner : MonoBehaviour
{
    public bool isMovable
    {
        get => _isMovable;
        set
        {
            _isMovable = value;
            if (value == false)
                speedModified = 0.0f;
        }
    }
    private bool _isMovable = true;

    public float speedModified
    {
        get => _speedModfied;
        set
        {
            _speedModfied = value;
            _animator.SetFloat("speed", value);
        }
    }

    [SerializeField] private float _speed = 3.0f;
    private float _speedModfied;

    [SerializeField] private float _speedmodifyingPeriod;
    private float _modifyingTimer;
    [Range(0.0f, 1.0f)][SerializeField] private float _stability;

    private Animator _animator;

    public void Finish(int grade)
    {
        isMovable = false;

        _animator.Play("Salute");
        switch (grade) 
        {
            case 0:
                _animator.Play("Jumping");
                break;
            case 1:
            case 2:
                _animator.Play("Salute");
                break;
            default:
                _animator.Play("KneelDown");
                break;
        }

        PlayManager.instance.RegisterRunnerFinished(this);
    }

    private void Awake()
    {
        
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayManager.instance.RegisterRunnerFinished(this);
    }

    //이동거리 = 속력 * 시간
    //고정 프레임당 이동거리 = 속력 * 고정 프레임간 시간변화

    private void FixedUpdate()
    {
        if (_isMovable == false)
            return;

        if(_modifyingTimer <= 0.0f)
        {
            //여기서 속도 조절
            speedModified = _speed * Random.Range(_stability, 1.0f);
            _modifyingTimer = _speedmodifyingPeriod;
        }
        //transform.position += Vector3.forward* _speed *Time.fixedDeltaTime;
        transform.Translate(Vector3.forward * _speedModfied * Time.fixedDeltaTime);// 위치 변화
    }
}
