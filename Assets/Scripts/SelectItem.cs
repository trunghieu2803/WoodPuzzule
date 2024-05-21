using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class SelectItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    SpawnThumbnail _spawnThumbnail;

    SpriteRenderer _sprite;
    GameManager gameManager;
    //int _index;
    private void Start()
    {
        gameManager = GameManager.Instant;
        _spawnThumbnail = this.GetComponentInParent<SpawnThumbnail>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameManager._index < _spawnThumbnail.ListThumnail.Count)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(eventData.position);
            gameManager.level.ListPiece[gameManager._index].transform.position = pos + new Vector2(0, 2f);
        }        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameManager.checkMove == false)
        {
            for (int i = 0; i < _spawnThumbnail.ListThumnail.Count; i++)
            {
                if (_spawnThumbnail.ListThumnail[i].name.Equals(this.gameObject.name))
                {
                    //_index = i;
                    gameManager._index = i;
                    Vector2 pos = Camera.main.ScreenToWorldPoint(eventData.position);
                    this.GetComponent<Image>().enabled = false;
                    _sprite = gameManager.level.ListPiece[i];
                    gameManager.level.ListPiece[i].sortingOrder = 10;
                    gameManager.level.ListPiece[i].enabled = true;
                    gameManager.level.ListPiece[i].transform.position = pos + new Vector2(0, 2f);
                    gameManager.checkMove = true;
                }
            }
        }
    }

    // Hàm xử lý khi thả chuột lên
    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instant.checkTarget = true;
        //_sprite.enabled = false;
        //Destroy(this.gameObject);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        StartCoroutine(checktarget());
    }

    IEnumerator checktarget()
    {
        yield return new WaitForSeconds(0.2f);
        if (gameManager.finalTarget == true)
        {
            gameManager.checkMove = false;
            this.GetComponent<Image>().gameObject.SetActive(false);
            _sprite.enabled = true;
            gameManager.checknextLevel++;
            gameManager.checkTarget = false;
            gameManager.finalTarget = false;
            gameManager.wingame(gameManager.checknextLevel);
        }
        else
        {
            gameManager._index = 10000;
            gameManager.checkTarget = false;
            gameManager.checkMove = false;
            this.GetComponent<Image>().enabled = true;
            _sprite.enabled = false;
        }
    }
}
