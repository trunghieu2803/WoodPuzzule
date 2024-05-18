using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Transform _transform;

    private Level _level;
    public Level level =>  _level;

    public bool finalTarget = false;

    public bool checkMove = false;

    public bool checkTarget = false;

    public int _index = 10000;
    void Start()
    {
        _level = _transform.GetComponentInChildren<Level>();
    }
}
