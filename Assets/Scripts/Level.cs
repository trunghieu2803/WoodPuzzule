using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<Transform> _listTransform; 

    public List<Transform> ListTransform => _listTransform;

    [SerializeField] List<SpriteRenderer> _listPiece;

    public List<SpriteRenderer> ListPiece => _listPiece;

    [SerializeField] List<Sprite> _ListSprite_Thumbnail;

    public List<Sprite> ListSpriteThumbnail => _ListSprite_Thumbnail;
    

    private void Update()
    {
        if (GameManager.Instant._index < _listTransform.Count)
        {
            float distance = Vector2.Distance(_listPiece[GameManager.Instant._index].transform.position, _listTransform[GameManager.Instant._index].position);
            if (distance > 0 && distance < 0.3f && GameManager.Instant.checkTarget)
            {
                _listPiece[GameManager.Instant._index].transform.position = _listTransform[GameManager.Instant._index].position;
                _listPiece[GameManager.Instant._index].sortingOrder = 2;
                GameManager.Instant._index = 10000;
                GameManager.Instant.finalTarget = true;
                GameManager.Instant.checkTarget = false;
            }
        }
    }
}
