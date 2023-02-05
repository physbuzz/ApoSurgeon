using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HumorIndividual : MonoBehaviour
{

    public Sprite emptySprite;
    public Sprite halfSprite;
    public Sprite fullSprite;

    private float m_level=100.0f;
    public float Level
    {
        get { return m_level; }
        set
        {
            m_level = value;

        }
    }
    public void UpdateImage()
    {
        if (m_level < 100f / 3)
        {
            GetComponent<SpriteRenderer>().sprite = emptySprite;
        } 
        else if (m_level < 200f / 3)
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
