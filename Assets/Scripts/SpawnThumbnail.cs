using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnThumbnail : MonoBehaviour
{
    [SerializeField] Image _image;

    List<Image> _listThumnail = new List<Image>();
    public List<Image> ListThumnail => _listThumnail;

    private void OnEnable()
    {
        StartCoroutine(waiupdatelist());
    }
    private void OnDisable()
    {
        foreach (var img in _listThumnail)
        {
            Destroy(img.gameObject);
        }
        StopCoroutine(waiupdatelist());
    }

    IEnumerator waiupdatelist()
    {
        _listThumnail.Clear();
        yield return new WaitForSeconds(0.1f);
        int i = 0;
        foreach (Sprite s in GameManager.Instant.level.ListSpriteThumbnail)
        {
            _image.sprite = s;
            _image.SetNativeSize();
            _image.name = i.ToString();
            Image E = Instantiate<Image>(_image, this.transform.position, Quaternion.identity, this.transform);
            _listThumnail.Add(E);
            i++;
        }
    }
}
