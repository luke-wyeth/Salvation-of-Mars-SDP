using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconController : MonoBehaviour
{
    //public bool isBoostImgOn, isGravityImgOn, isCloneImgOn;
    //public bool isImgOn;
    //public Image boostAbilityIcon, gravityAbilityIcon;
    public GameObject boostAbilityObj, gravityAbilityObj, cloneAbilityObj;
    private GameObject boostAbilityChild, gravityAbilityChild, cloneAbilityChild;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(boostAbilityObj.transform.GetChild(0).gameObject);
        boostAbilityChild = boostAbilityObj.transform.GetChild(0).gameObject;
        boostAbilityChild.SetActive(false);

        gravityAbilityChild = gravityAbilityObj.transform.GetChild(0).gameObject;
        gravityAbilityChild.SetActive(false);

        cloneAbilityChild = cloneAbilityObj.transform.GetChild(0).gameObject;
        cloneAbilityChild.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SkillSelect.boostSelected)
        {
            boostAbilityChild.SetActive(true);
        }
        else if (SkillSelect.gravitySelected)
        {
            gravityAbilityChild.SetActive(true);
        }
        else if (SkillSelect.cloneSelected)
        {
            cloneAbilityChild.SetActive(true);
        }
    }
}
