using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HumorIndividual : MonoBehaviour
{

    public Sprite emptySprite;
    public Sprite halfSprite;
    public Sprite fullSprite;

    private float m_level=1.0f;
    public float Level
    {
        get { return m_level; }
        set
        {
            m_level = value;
            UpdateImage();
        }
    }
    public void UpdateImage()
    {
        if (m_level < 1f / 3)
        {
            GetComponent<SpriteRenderer>().sprite = emptySprite;
        } 
        else if (m_level < 2f / 3)
        {
            GetComponent<SpriteRenderer>().sprite = halfSprite;
        } 
        else
        {
            GetComponent<SpriteRenderer>().sprite = fullSprite;
        }
    }
    public void Awake()
    {
        UpdateImage();
    }


}
