using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconController : MonoBehaviour
{
    //public bool isBoostImgOn, isGravityImgOn, isCloneImgOn;
    public bool isImgOn;
    public Image boostAbilityIcon, gravityAbilityIcon;

    // Start is called before the first frame update
    void Start()
    {
        boostAbilityIcon.enabled = false;
        gravityAbilityIcon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SkillSelect.boostSelected)
        {
            isImgOn = true;
            boostAbilityIcon.enabled = true;
        }
        else if (SkillSelect.gravitySelected)
        {
            isImgOn = true;
            gravityAbilityIcon.enabled = true;
        }
        else if (SkillSelect.cloneSelected)
        {
            //isCloneImgOn = true;
            //isBoostImgOn = false;
            //isGravityImgOn = false;
        }
    }
}
