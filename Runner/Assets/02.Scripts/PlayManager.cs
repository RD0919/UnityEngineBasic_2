using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//싱글톤 질문 필요
public class PlayManager : MonoBehaviour
{
    public static PlayManager instance
    {
        get
        {
            if(_instance == null)
                _instance = new GameObject().AddComponent<PlayManager>();
            return _instance;
        }
    }
    private static PlayManager _instance;

    private void Awake()
    {
        if( _instance != null )
        {
            Destroy( _instance.gameObject );
        }
        _instance = this;
    }

    private Runner[] _runners = new Runner[5];
    private Runner[] _runnersFinished = new Runner[5];
    private int _runnerCount;
    private int _runnerFinshedCount;
    [SerializeField] private Transform[] _platforms;
    public void RegisterRunner(Runner runner)
    {
        _runners[_runnerCount] = runner;
        _runnerCount++;
    }
    public void RegisterRunnerFinished(Runner runner)
    {
        _runnersFinished[_runnerFinshedCount] = runner;
        _runnerFinshedCount++;
        if(_runnerFinshedCount >= _runnerCount)
        {
            Invoke("PlaceRunnersOnPlatform", 3.0f);
        }
    }
    private void PlaceRunnersOnPlatform()
    {
        for (int i = 0; i < _platforms.Length; i++)
        {
            _runnersFinished[i].transform.position = _platforms[i].position;
        }
    }
}
