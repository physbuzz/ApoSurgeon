using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnimController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        GameManager.instance.onPainLevelChanged += OnPainLevelChanged;
        GameManager.instance.onToolAppliedOnFace += OnToolAppliedOnFace;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnToolAppliedOnFace(ToolType toolType, FacePart FacePart)
    {
        if (toolType == ToolType.HAMMER)
        {
            animator.SetTrigger("triggerBonked");
        }

    }

    void OnPainLevelChanged(float painLevel)
    {
        if (painLevel > 0)
        {
            animator.SetTrigger("triggerScream");
        }
    }

}
