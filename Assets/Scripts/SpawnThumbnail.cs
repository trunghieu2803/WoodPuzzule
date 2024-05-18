using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnThumbnail : MonoBehaviour
{
    [SerializeField] Image _image;

    List<Image> _listThumnail = new List<Image>();
    public List<Image> ListThumnail => _listThumnail;
    private void Start() {
        StartCoroutine(waiupdatelist());
    }

    IEnumerator waiupdatelist()
    {
        yield return new WaitForSeconds(0.5f);
        int i = 0;
        foreach (Sprite s in GameManager.Instant.level.ListSprite)
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
