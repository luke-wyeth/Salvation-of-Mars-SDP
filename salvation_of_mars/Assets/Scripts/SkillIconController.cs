using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconController : MonoBehaviour
{
    //public bool isBoostImgOn, isGravityImgOn, isCloneImgOn;
    //public bool isImgOn;
    //public Image boostAbilityIcon, gravityAbilityIcon;
    public CloneController cloneController;
    public PlayerMovement playerMovement;
    public Image boostCooldownBar, gravityCooldownBar, cloneCooldownBar;
    public GameObject boostAbilityObj, gravityAbilityObj, cloneAbilityObj;

    private const float TIME_UNTIL_ABILITY_READY = 0.0165f;

    // Start is called before the first frame update
    void Start()
    {
        boostCooldownBar.fillAmount = 1;
        gravityCooldownBar.fillAmount = 1;
        cloneCooldownBar.fillAmount = 0;

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
            StartCoroutine(boostCooldownProgress());
        }
        else if (SkillSelect.gravitySelected)
        {
            gravityAbilityObj.SetActive(true);
            boostAbilityObj.SetActive(false);
            cloneAbilityObj.SetActive(false);
            StartCoroutine(gravityCooldownProgress());
        }
        else if (SkillSelect.cloneSelected)
        {
            cloneAbilityObj.SetActive(true);
            boostAbilityObj.SetActive(false);
            gravityAbilityObj.SetActive(false);

            StartCoroutine(cloneCooldownProgress());
            //Cool down bar flashing in between 2 colours while in use
        }
    }

    private IEnumerator boostCooldownProgress()
    {
        if (playerMovement.isSpeedBoostReady())
        {
            boostCooldownBar.fillAmount = 0;
        }
        else
        {
            boostCooldownBar.fillAmount += TIME_UNTIL_ABILITY_READY;
        }
        yield return null;
    }

    private IEnumerator gravityCooldownProgress()
    {
        if (playerMovement.isGravityReady())
        {
            gravityCooldownBar.fillAmount = 0;
        } 
        else
        {
            gravityCooldownBar.fillAmount += TIME_UNTIL_ABILITY_READY;
        }

        yield return null;
    }

    private IEnumerator cloneCooldownProgress()
    {
        //if (cloneController.clone.activeSelf)
        //{
        //    cloneCooldownBar.color = Color.red;
        //    yield return new WaitForSecondsRealtime(.5f);
        //    cloneCooldownBar.color = Color.blue;
        //}

        while (cloneController.getCloneControl().enabled)
        {
            cloneCooldownBar.fillAmount = 1;
            cloneCooldownBar.color = new Color(253/255f, 149/255f, 0);
            yield return new WaitForSeconds(0.5f);
            cloneCooldownBar.color = Color.clear;
        }

    }
}
