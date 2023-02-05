using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject bloodBarGameObject;
    public GameObject yellowBileGameObject;
    public GameObject blackBileGameObject;
    public GameObject phlegmGameObject;



    public HumorIndividual bloodSprite;
    public HumorIndividual yellowSprite;
    public HumorIndividual blackSprite;
    public HumorIndividual phlegmSprite;

    private Slider bloodBar;
    private Slider yellowBileBar;
    private Slider blackBileBar;
    private Slider phlegmBar;

    public float test;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onBloodValueChanged += HandleBloodValueChanged;
        GameManager.instance.onPhlegmValueChanged += HandlePhlegmValueChanged;
        GameManager.instance.onBlackBileValueChanged += HandleBlackBileValueChanged;
        GameManager.instance.onYellowBileValueChanged += HandleYellowBileValueChanged;


        bloodBar = bloodBarGameObject?.GetComponent<Slider>();
        yellowBileBar = yellowBileGameObject?.GetComponent<Slider>();
        blackBileBar = blackBileGameObject?.GetComponent<Slider>();
        phlegmBar = phlegmGameObject?.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void HandleBloodValueChanged(float value)
    {
        if (bloodBar == null)
        {
            return;
        }

        bloodBar.value = value;
        bloodSprite.Level = value;
    }
    void HandlePhlegmValueChanged(float value)
    {
        if (phlegmBar == null)
        {
            return;
        }

        phlegmBar.value = value;
        phlegmSprite.Level = value;
    }

    void HandleBlackBileValueChanged(float value)
    {
        if (blackBileBar == null)
        {
            return;
        }
        blackBileBar.value = value;
        blackSprite.Level = value;
    }
    void HandleYellowBileValueChanged(float value)
    {
        if (yellowBileBar == null)
        {
            return;
        }
        yellowBileBar.value = value;
        yellowSprite.Level = value;
    }

}
