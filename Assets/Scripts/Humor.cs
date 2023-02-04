using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humor : MonoBehaviour
{

    private float m_blood;
    private float m_yellowBile;
    private float m_blackBile;
    private float m_phlegm;
    public float Blood
    {
        get { return m_blood; }
        set
        {
            m_blood = value; 
        }
    }

    public float BlackBile
    {
        get { return m_blackBile; }
        set
        {
            m_blackBile = value;
        }
    }

    public float YellowBile
    {
        get { return m_yellowBile; }
        set
        {
            m_yellowBile = value;
        }
    }

    public float Phlegm
    {
        get { return m_phlegm; }
        set
        {
            m_phlegm = value;
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
        
    }


}
