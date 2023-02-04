using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    public ProgressBar Blood;
    public Button test;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        Blood = root.Q<ProgressBar>("BloodBar");
        Blood.value = 50;

        GameManager.instance.onHumorBloodValueChanged += HandleHumorBloodValueChanged;
    }

    // Update is called once per frame
    void Update()
    {
        Blood.value += 1;
    }

    void HandleHumorBloodValueChanged(int value)
    {
        Blood.value = value;
    }
}
