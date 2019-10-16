using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconController : MonoBehaviour
{
    //public bool isBoostImgOn, isGravityImgOn, isCloneImgOn;
    //public bool isImgOn;
    //public Image boostAbilityIcon, gravityAbilityIcon;
    public Image boostCooldownBar, gravityCooldownBar, cloneCooldownBar;
    public GameObject boostAbilityObj, gravityAbilityObj, cloneAbilityObj;

    // Start is called before the first frame update
    void Start()
    {
        boostCooldownBar.fillAmount = 1;
        gravityCooldownBar.fillAmount = 1;
        cloneCooldownBar.fillAmount = 1;
        boostAbilityObj.SetActive(false);
        gravityAbilityObj.SetActive(false);
        cloneAbilityObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SkillSelect.boostSelected)
        {
            boostAbilityObj.SetActive(true);
            gravityAbilityObj.SetActive(false);
            cloneAbilityObj.SetActive(false);
            StartCoroutine(cooldownProgress(boostCooldownBar));
        }
        else if (SkillSelect.gravitySelected)
        {
            gravityAbilityObj.SetActive(true);
            boostAbilityObj.SetActive(false);
            cloneAbilityObj.SetActive(false);
            StartCoroutine(cooldownProgress(gravityCooldownBar));
        }
        else if (SkillSelect.cloneSelected)
        {
            cloneAbilityObj.SetActive(true);
            boostAbilityObj.SetActive(false);
            gravityAbilityObj.SetActive(false);
            //Cool down bar flashing in between 2 colours while in use
        }
    }

    private IEnumerator cooldownProgress(Image cooldownBar)
    {
        //cooldownBar.fillAmount += 0.01f;
        //yield return null;
        float timeLeft = Time.deltaTime;
        float rate = 1.0f / 0.8f;

        float progress = 0f;

        while (progress <= 1f)
        {
            cooldownBar.fillAmount = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
    }
}
