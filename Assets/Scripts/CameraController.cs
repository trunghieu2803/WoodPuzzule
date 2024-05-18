using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] float originOrthoSize = 7.5f;
    void Start()
    {
        StartCoroutine(GetScreenSize());
    }


    private IEnumerator GetScreenSize()
    {
        yield return new WaitForEndOfFrame();
        var ratio = Screen.height / (Screen.width * 1f);
        var scale = ratio / (16 / 9f);
        Camera.main.orthographicSize = originOrthoSize * scale;

        if (scale < 1)
        {
            Camera.main.orthographicSize = originOrthoSize / scale;
        }
    }
}
