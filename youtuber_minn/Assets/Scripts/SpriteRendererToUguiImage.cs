using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpriteRendererToUguiImage : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Image _image;

    public Image DarkCurcle;


    // Use this for initialization
    void Start()
    {

        if (_spriteRenderer == null)
            _spriteRenderer = this.GetComponent<SpriteRenderer>();

        _spriteRenderer.enabled = false;

        if (_image == null)
            _image = this.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

        _image.sprite = _spriteRenderer.sprite;

        if (GameManager.health < 10) DarkCurcle.gameObject.SetActive(true);
        else DarkCurcle.gameObject.SetActive(false);

    }
}
