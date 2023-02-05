using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;

public enum FacePart
{
    None,
    ForeHead,
    Nose,
    Cheek,
    Jaw
}

public enum ToolType 
{ 
    BONESAW, 
    LEECHES,
    SCALPEL, 
    DRILL,
    NIGHTSHADE,
    WINTERGREEN,
    MERCURY,
    POWDEREDMUMMY,
    WITCHROOT,
    HAMMER,
    None
};

public enum ToolEffect 
{ 
    Blood, 
    YellowBile, 
    BlackBile, 
    Phlegm, 
    ForeHead,
    Nose,
    Cheek,
    Jaw,
    Num
};

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public delegate void OnHumorValueChanged(float value);

    public OnHumorValueChanged onBloodValueChanged;
    public OnHumorValueChanged onPhlegmValueChanged;
    public OnHumorValueChanged onBlackBileValueChanged;
    public OnHumorValueChanged onYellowBileValueChanged;

    public delegate void OnToolAppliedOnFace(ToolType toolType, FacePart FacePart);
    public OnToolAppliedOnFace onToolAppliedOnFace;
    public FacePart mouseHoveredFacePart;

    public delegate void OnPainLevelChanged(float PainLevel);
    public OnPainLevelChanged onPainLevelChanged;

    public delegate void OnToolHoveredAction(ToolType toolType);
    public OnToolHoveredAction onToolHovered;
    public ToolType toolHovered;

    public bool isDragging = false;


    public TextAsset ToolsEffectCSV;
    public Dictionary<ToolType, float[]> ToolsEffectTable;

    public Humor humor;

    public GameObject gameVictoryPanel;


    public float painTimerMinRange = 30;
    public float painTimerMaxRange = 60;
    public float nextPainTimer = 60;

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

        if (ToolsEffectCSV)
        {
            ToolsEffectTable = new Dictionary<ToolType, float[]>();
            ParseToolEffectCSV();
        }

    }

    private void Start()
    {


        humor.BlackBile = 60;
        humor.YellowBile = 60;
        humor.Blood = 60;
        humor.Phlegm = 60;
        nextPainTimer = Time.time + nextPainTimer;
    }
    public void OnToolHovered(ToolType toolType)
    {
        onToolHovered(toolType);
    }
    public void OnToolDragReleased(ToolType toolType)
    {

        if (mouseHoveredFacePart == FacePart.None)
        {
            return;
        }

        onToolAppliedOnFace(toolType, mouseHoveredFacePart);

        float[] valueTable;
        if (ToolsEffectTable.TryGetValue(toolType, out valueTable) == false)
        {
            return;
        }

        for (int i = 0; i < valueTable.Length; ++i)
        {
            if (Mathf.Approximately(0.0f, valueTable[i]))
            {
                continue;
            }

            switch ((ToolEffect)i)
            {
                case ToolEffect.Blood:
                    humor.Blood += valueTable[i];
                    break;
                case ToolEffect.YellowBile:
                    humor.YellowBile += valueTable[i];
                    break;
                case ToolEffect.BlackBile:
                    humor.BlackBile += valueTable[i];
                    break;
                case ToolEffect.Phlegm:
                    humor.Phlegm += valueTable[i];
                    break;
                case ToolEffect.ForeHead:

                    break;
                case ToolEffect.Nose:

                    break;
                case ToolEffect.Cheek:

                    break;
                case ToolEffect.Jaw:

                    break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            humor.BlackBile = 11;// humor.maxBlackBile;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            humor.YellowBile = 11;//humor.maxYellowBile;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            humor.Blood = 11;//humor.maxBlood;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            humor.Phlegm = 11;//humor.maxPhlegm;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            onToolAppliedOnFace(ToolType.HAMMER, mouseHoveredFacePart);
            ResetPainLevelChangeTimer();
        }

        RandomPainLevelChangeWithTime();
    }
    void RandomPainLevelChangeWithTime()
    {
        //Check if current system time is greater than nextTime
        if (Time.time > nextPainTimer)
        {
            onPainLevelChanged(1);
            ResetPainLevelChangeTimer();
        }
    }
    void ResetPainLevelChangeTimer()
    {
        // reset scream timer
        float modifier = UnityEngine.Random.Range(painTimerMinRange, painTimerMaxRange);

        //Set nextTime equal to current run time plus modifier
        nextPainTimer = Time.time + modifier;
    }
    void ParseToolEffectCSV()
    {
        //var dataset = Resources.Load<TextAsset>("box");
        string[] lines = (ToolsEffectCSV.text.Split('\n'));

        for (var i = 1; i < lines.Length; i++)
        {
            float[] valueTable = new float[(int)ToolEffect.Num];

            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                Debug.LogError("Empty row");
                continue;
            }

            string[] row = lines[i].Split(',');
            if (row.Length <= (int)ToolEffect.Num)
            {
                Debug.LogError("Empty column");
                continue;
            }

            ToolType outToolType;
            if (Enum.TryParse(row[0], true, out outToolType) == false)
            {
                Debug.LogError("Invalid tool type for first column");
                continue;
            }

            for (int j = 0; j < (int)ToolEffect.Num; ++j)
            {
                valueTable[j] = float.Parse(row[j+1]);
            }

            ToolsEffectTable.Add(outToolType, valueTable);
        }
    }
}
