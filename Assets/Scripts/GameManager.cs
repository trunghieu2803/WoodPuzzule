using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Transform _transform;
    [SerializeField] public Image _imgwin;
    [SerializeField] public SkeletonAnimation _anim;
    [SerializeField] LevelMenu _levelMenu;
    [SerializeField] TextMeshProUGUI _textMeshProUGUI;
    int coin = 0;
    private Level _level;
    public Level level =>  _level;

    public bool finalTarget;

    public bool checkMove;

    public bool checkTarget;

    public int _index;

    public int checknextLevel;
    private void OnEnable()
    {
        _textMeshProUGUI.text = coin.ToString();
        finalTarget = false;
        checkMove = false;
        checkTarget = false;
        _index = 10000;
        checknextLevel = 0;
        _level = _transform.GetComponentInChildren<Level>();
    }

    public void wingame(int chekcwin)
    {
        if (chekcwin == level.ListTransform.Count)
        {
            StartCoroutine(waitingforwin());
        }
    }

    IEnumerator waitingforwin()
    {
        yield return new WaitForSeconds(0.2f);

        coin += 100;
        _imgwin.gameObject.SetActive(true);
        _anim.gameObject.SetActive(true);
        _anim.state.SetAnimation(0, "animation", false);

        bool clearListChildrent = false;

        Transform[] _listChildrentThumbnail = _levelMenu._transParentThumbnailUI.GetComponentsInChildren<Transform>();
        if (_listChildrentThumbnail.Length > 1)
        {
            for (int i = 1; i < _listChildrentThumbnail.Length; i++)
            {
                if (!_listChildrentThumbnail[i].gameObject.name.Equals(_levelMenu._transParentThumbnailUI.gameObject.name))
                {
                    Destroy(_listChildrentThumbnail[i].gameObject);
                    if (i == _listChildrentThumbnail.Length - 1)
                    {
                        clearListChildrent = true;
                    }
                }
            }
        }
        else clearListChildrent = true;

        _levelMenu._gameManager.gameObject.SetActive(false);
        if (clearListChildrent)
            _levelMenu._rectBoardtransform.gameObject.SetActive(false);

       
    }
}
