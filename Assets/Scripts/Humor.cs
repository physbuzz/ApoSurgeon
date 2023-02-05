using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humor : MonoBehaviour
{
    public float maxBlood = 100;
    public float maxYellowBile = 100;
    public float maxBlackBile = 100;
    public float maxPhlegm = 100;

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
            GameManager.instance.onBloodValueChanged(NormalizedClamp(m_blood, maxBlood));
        }
    }

    public float BlackBile
    {
        get { return m_blackBile; }
        set
        {
            m_blackBile = value;
            GameManager.instance.onBlackBileValueChanged(NormalizedClamp(m_blackBile, maxBlackBile));
        }
    }

    public float YellowBile
    {
        get { return m_yellowBile; }
        set
        {
            m_yellowBile = value;
            GameManager.instance.onYellowBileValueChanged(NormalizedClamp(m_yellowBile, maxYellowBile));
        }
    }

    public float Phlegm
    {
        get { return m_phlegm; }
        set
        {
            m_phlegm = value;
            GameManager.instance.onPhlegmValueChanged(NormalizedClamp(m_phlegm, maxPhlegm));
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float NormalizedClamp(float value, float max)
    {
        return Mathf.Clamp01(value / max);
    }    
}
