using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{

    public GameObject[] faces;

    public int cheekBeauty = 0;
    public int chinBeauty = 0;
    public int foreheadBeauty = 0;
    public int noseBeauty = 0;

    //public GameObject
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onToolAppliedOnFace += HandleToolAppliedOnFace;
    }

    public void HandleToolAppliedOnFace(ToolType toolType, FacePart FacePart)
    {

    }
}
