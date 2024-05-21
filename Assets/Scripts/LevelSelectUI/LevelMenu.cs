using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> list;
    [SerializeField] Transform _spawnLevelTransform;
    [SerializeField] Transform _transParentThumbnailUI;
    [SerializeField] Transform _gameManager;
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] RectTransform _rectBoardtransform;
    [SerializeField] TextMeshProUGUI _textMeshProUGUI;
    public void OpenLevel(int levelId)
    {

        foreach (GameObject g in list)
        {
            if(g.name.Equals("Level_" + levelId))
            {
                _textMeshProUGUI.text = "LEVEL " + levelId;
                Instantiate(g, Vector2.zero, Quaternion.identity, _spawnLevelTransform);
                _rectTransform.gameObject.SetActive(false);
                _gameManager.gameObject.SetActive(true);
                _rectBoardtransform.gameObject.SetActive(true);
            }
        }
    }

    public void LevelSelection()
    {
        bool clearListChildrent = false;

        Transform[] _listChildrentThumbnail = _transParentThumbnailUI.GetComponentsInChildren<Transform>();
        if (_listChildrentThumbnail.Length > 1)
        {
            for(int i = 1; i < _listChildrentThumbnail.Length; i++)
            {
                if (!_listChildrentThumbnail[i].gameObject.name.Equals(_transParentThumbnailUI.gameObject.name))
                {
                    Destroy(_listChildrentThumbnail[i].gameObject);
                    if(i == _listChildrentThumbnail.Length - 1)
                    {
                        clearListChildrent = true;  
                    }
                }
            }
        }else clearListChildrent = true;

        Transform _transformLevel = _spawnLevelTransform.GetChild(0).transform;
        Destroy(_transformLevel.gameObject);
        _gameManager.gameObject.SetActive(false);
        _rectTransform.gameObject.SetActive(true);
        if(clearListChildrent) 
            _rectBoardtransform.gameObject.SetActive(false);
    }
}
