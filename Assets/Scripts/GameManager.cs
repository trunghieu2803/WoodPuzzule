using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Transform _transform;

    private Level _level;
    public Level level =>  _level;

    public bool finalTarget;

    public bool checkMove;

    public bool checkTarget;

    public int _index;
    private void OnEnable()
    {
        finalTarget = false;
        checkMove = false;
        checkTarget = false;
        _index = 10000;
        _level = _transform.GetComponentInChildren<Level>();
    }

    private void OnDisable()
    {
        
    }
}
