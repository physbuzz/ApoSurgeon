using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletController : MonoBehaviour
{
    public GameObject BloodDropletGO;
    public GameObject YellowDropletGO;
    public GameObject BlackDropletGO;
    public GameObject PhlegmDropletGO;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onBloodValueChanged += HandleBloodValueChanged;
        GameManager.instance.onYellowBileValueChanged += HandleYellowValueChanged;
        GameManager.instance.onBlackBileValueChanged += HandleBlackValueChanged;
        GameManager.instance.onPhlegmValueChanged += HandlePhlegmValueChanged;
    }

    // Update is called once per frame
    void HandleBloodValueChanged(float Value)
    {
           BloodDropletGO?.SetActive(Value < 0.5f);
    }

    void HandleYellowValueChanged(float Value)
    {
        YellowDropletGO?.SetActive(Value < 0.5f);
    }

    void HandleBlackValueChanged(float Value)
    {
        BlackDropletGO?.SetActive(Value < 0.5f);
    }

    void HandlePhlegmValueChanged(float Value)
    {
        PhlegmDropletGO?.SetActive(Value < 0.5f);
    }
}
