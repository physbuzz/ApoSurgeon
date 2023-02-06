using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class IntroText : MonoBehaviour, IPointerClickHandler
{

    public GameObject[] text;
    private int curText = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (curText == 0)
        {
            text[0].SetActive(false);
            text[1].SetActive(true);
            curText++;

        } 
        else if (curText == 1)
        {
            text[0].SetActive(false);
            text[1].SetActive(false);
            GameManager.instance.gameState=GameState.PLAY;
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        text[0].SetActive(true);
        text[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
