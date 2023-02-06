using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class TooltipScript : MonoBehaviour
{
    private Dictionary<ToolType, string> tooltiptext = new Dictionary<ToolType, string>();

    // Start is called before the first frame update
    public Text textcontent;
    private void Awake()
    {
        tooltiptext.Add(ToolType.MERCURY,
            "Mercury (+yellow bile, -phlegm): A shimmering liquid said to awaken a man’s inner fire and purify any clouded thoughts and dulled senses.");
        tooltiptext.Add(ToolType.WINTERGREEN, "Wintergreen (+phlegm, -blood): This plant exudes a crisp and invigorating essence that stimulates the body’s fluids and calms the overflow of life.");
        tooltiptext.Add(ToolType.NIGHTSHADE, "Nightshade (+black bile, -yellow bile): Its flowers, as dark as night, hold a potent and mysterious essence that calms overactive energies while stirring the stagnant ones.");
        tooltiptext.Add(ToolType.POWDEREDMUMMY, "Powdered Mummy (+blood, -black bile): A fine dust, made from the bones of a blessed man, that can grant life-giving energy and banish any dark spirits within.");
        tooltiptext.Add(ToolType.WITCHROOT, "Witchroot (reset): A mysterious root, unknown in origin. How its restorative properties can rejuvenate the body and mind is still a mystery.");
        tooltiptext.Add(ToolType.BONESAW, "Bonesaw (Jaw): A keen edge that, in the hands of a skilled practitioner, can reshape bone.");
        tooltiptext.Add(ToolType.DRILL, "Drill (Forehead): An articulate tool capable of excavating material from the forehead of a victim or patient.");
        tooltiptext.Add(ToolType.LEECHES, "Leeches (Nose): Tiny creatures that cleanse the body of any ailments and impurities.");
        tooltiptext.Add(ToolType.SCALPEL, "Scalpel (Cheeks): A new innovative tool that cleanly slices through the delicate layers of skin and fat.");
        tooltiptext.Add(ToolType.None, "");
    }
    void Start()
    {
        GameManager.instance.onToolHovered += HandleToolHovered;
    }

    private void Update()
    {
        if (!GameManager.instance.isDragging && GameManager.instance.mouseHoveredFacePart != FacePart.None)
        {
            switch(GameManager.instance.mouseHoveredFacePart)
            {
                case FacePart.None:
                    Debug.Log("what");
                    break;
                case FacePart.ForeHead:
                    textcontent.text = FaceHoveredString(FacePart.ForeHead, GameManager.instance.headController.foreheadBeauty);
                    break;
                case FacePart.Nose:
                    textcontent.text = FaceHoveredString(FacePart.Nose, GameManager.instance.headController.noseBeauty);
                    break;
                case FacePart.Jaw:
                    textcontent.text = FaceHoveredString(FacePart.Jaw, GameManager.instance.headController.jawBeauty);
                    break;
                case FacePart.Cheek:
                    textcontent.text = FaceHoveredString(FacePart.Cheek, GameManager.instance.headController.cheekBeauty);
                    break;
            }
        }
    }

    public void HandleToolHovered(ToolType toolType)
    {
        textcontent.text= tooltiptext[toolType];
    }
    public string FaceHoveredString(FacePart facePart, int value)
    {
        string descriptor;
        switch(value)
        {
            case 0:
                descriptor = "Horrible";
                break;
            case 1:
                descriptor = "Weird";
                break;
            case 2:
                descriptor = "Handsdome";
                break;
            default:
                descriptor = "Descriptor missing";
                break;
        }
        return facePart.ToString() + " description: " + descriptor;
    }

}
