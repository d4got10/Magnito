using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animation))]
public class SpriteDestruction : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Transform _parent;

    [SerializeField] private Animation _animation;

    [SerializeField] private List<GameObject> partObjects;


    public void DestroyButton()
    {
        Texture2D sourceTexture = _image.sprite.texture;

        int textureWidth = sourceTexture.width;
        int textureHeight = sourceTexture.height;

        for(int i = 0; i < 4; i++)
        {
            Rect spriteRect = new Rect(textureWidth / 2 * Mathf.FloorToInt(i / 2), textureHeight / 2 * (i % 2), textureWidth / 2, textureHeight / 2);
            Sprite sprite = Sprite.Create(sourceTexture, spriteRect, new Vector2(0.5f, 0.5f));

            GameObject part = partObjects[i];

            Image partImage = part.GetComponent<Image>();
            partImage.sprite = sprite;
            part.SetActive(true);
        }

        _image.enabled = false;
        _animation.Play();
        enabled = false;
    }
}
