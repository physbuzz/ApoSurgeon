using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

[RequireComponent(typeof(SpriteRenderer))]
public class FaceBlinker : MonoBehaviour
{
    public Color colorFrom = new Color(1f, 1f, 1f, 0.2f);
    public Color colorTo = new Color(1f, 1f, 1f, 1f);
    private Color colorTransparent = new Color(1f, 1f, 1f, 0f);
    private bool isHovered=false;
    private float t=0.0f;
    private const float omega = 6.0f;
    private const float speed =5.0f;


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        t = 0.0f;
    }
    public void setHover(bool arg)
    {
        isHovered= arg;
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (isHovered)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(
                    GetComponent<SpriteRenderer>().color,
                    Color.Lerp(colorFrom,colorTo, 0.5f * (1 + Mathf.Cos(omega * t))),
                    Time.deltaTime*speed
                );
        } 
        else
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(
                    GetComponent<SpriteRenderer>().color,
                    colorTransparent,
                    Time.deltaTime * speed
                );
        }

    }
}
