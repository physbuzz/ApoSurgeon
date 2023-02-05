using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceInput : MonoBehaviour
{
    public FacePart facePart;
    // Start is called before the first frame update

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        GameManager.instance.mouseHoveredFacePart = facePart;

        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color( .7f, .7f, .7f, 1);
        }
    }

    void OnMouseExit()
    {
        GameManager.instance.mouseHoveredFacePart = FacePart.None;

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
