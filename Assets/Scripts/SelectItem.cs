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
    //int _index;
    private void Start()
    {
        _spawnThumbnail = this.GetComponentInParent<SpawnThumbnail>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.Instant._index < _spawnThumbnail.ListThumnail.Count)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(eventData.position);
            GameManager.Instant.level.ListPiece[GameManager.Instant._index].transform.position = pos + new Vector2(0, 2f);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(GameManager.Instant.checkMove == false)
        {
            for (int i = 0; i < _spawnThumbnail.ListThumnail.Count; i++)
            {
                if (_spawnThumbnail.ListThumnail[i].name.Equals(this.gameObject.name))
                {
                    //_index = i;
                    GameManager.Instant._index = i;
                    Vector2 pos = Camera.main.ScreenToWorldPoint(eventData.position);
                    this.GetComponent<Image>().enabled = false;
                    _sprite = GameManager.Instant.level.ListPiece[i];
                    GameManager.Instant.level.ListPiece[i].sortingOrder = 10;
                    GameManager.Instant.level.ListPiece[i].enabled = true;
                    GameManager.Instant.level.ListPiece[i].transform.position = pos + new Vector2(0, 2f);
                    GameManager.Instant.checkMove = true;
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
        if (GameManager.Instant.finalTarget == true)
        {
            GameManager.Instant.checkMove = false;
            this.GetComponent<Image>().gameObject.SetActive(false);
            _sprite.enabled = true;
            GameManager.Instant.checkTarget = false;
            GameManager.Instant.finalTarget = false;
        }
        else
        {
            GameManager.Instant._index = 10000;
            GameManager.Instant.checkTarget = false;
            GameManager.Instant.checkMove = false;
            this.GetComponent<Image>().enabled = true;
            _sprite.enabled = false;
        }
    }
}
