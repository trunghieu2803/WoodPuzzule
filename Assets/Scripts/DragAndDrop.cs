using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    SpriteRenderer _sprite;
    Vector2 pos;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //    if (GameManager.Instant.checkMove)
        //    {
        //        this.transform.position = pos + new Vector2(0, 2f);
        //    }
        //}
    }

}
