using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceInput : MonoBehaviour
{
    public FacePart facePart;

    //State machine responsible for showing the hover sprite / flashing over time.
    public FaceBlinker faceBlinker;

    private void Awake()
    {
        
    }

    void OnMouseEnter()
    {
        GameManager.instance.mouseHoveredFacePart = facePart;

        if (faceBlinker != null)
        {
            faceBlinker.setHover(true);
        }
    }

    void OnMouseOver()
    {
        GameManager.instance.mouseHoveredFacePart = facePart;

        if (faceBlinker != null)
        {
            faceBlinker.setHover(true);
        }
    }

    void OnMouseExit()
    {
        GameManager.instance.mouseHoveredFacePart = FacePart.None;

        if (faceBlinker != null)
        {
            faceBlinker.setHover(false);
        }
    }
}
