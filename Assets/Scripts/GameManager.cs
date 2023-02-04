using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public delegate void OnHumorBloodValueChanged(int value);
    public OnHumorBloodValueChanged onHumorBloodValueChanged;
    public Humor humor;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        humor = new Humor();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("test update.");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
            humor.Blood = 5;
        }
    }
}
