using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeadController : MonoBehaviour
{

    public GameObject[] faces;

    public int cheekBeauty = 0;
    public int jawBeauty = 0;
    public int foreheadBeauty = 0;
    public int noseBeauty = 0;

    //public GameObject
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onToolAppliedOnFace += HandleToolAppliedOnFace;
    }

    public void Reset()
    {
        cheekBeauty = 0;
        jawBeauty = 0;
        foreheadBeauty = 0;
        noseBeauty = 0;
        HandleBeautyChanged();
    }

    public int TotalBeauty()
    {
        return cheekBeauty + noseBeauty + foreheadBeauty + jawBeauty;
    }
    public void HandleBeautyChanged()
    {
        if (faces.Length != 3)
        {
            Debug.Log("Error: HeadController.faces array should have 3 heads");
            return;
        }
        if (TotalBeauty() < 4)
        {
            faces[0].SetActive(true);
            faces[1].SetActive(false);
            faces[2].SetActive(false);
        }
        else if (TotalBeauty() < 7)
        {

            faces[0].SetActive(false);
            faces[1].SetActive(true);
            faces[2].SetActive(false);
        } 
        else
        {

            faces[0].SetActive(false);
            faces[1].SetActive(false);
            faces[2].SetActive(true);
        }
        if (TotalBeauty() == 8)
        {
            GameManager.instance.GameWin();
        }
    }

    public void HandleToolAppliedOnFace(ToolType toolType, FacePart facePart)
    {
        if (toolType == ToolType.BONESAW && facePart == FacePart.Jaw)
        {
            if (jawBeauty < 2)
                jawBeauty += 1;
        }
        if (toolType == ToolType.DRILL && facePart == FacePart.ForeHead)
        {
            if (foreheadBeauty < 2)
                foreheadBeauty += 1;
        }
        if (toolType == ToolType.LEECHES && facePart == FacePart.Nose)
        {
            if (noseBeauty < 2)
                noseBeauty += 1;
        }
        if (toolType == ToolType.SCALPEL && facePart == FacePart.Cheek)
        {
            if (cheekBeauty < 2)
                cheekBeauty += 1;
        }
        HandleBeautyChanged();

    }
}
