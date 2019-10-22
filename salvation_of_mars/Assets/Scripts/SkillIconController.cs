using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconController : MonoBehaviour
{
    public CloneController cloneController; //Need to reference the controller and movement scripts
    public PlayerMovement playerMovement;
    public Image boostCooldownBar, gravityCooldownBar, cloneCooldownBar;
    public GameObject boostAbilityObj, gravityAbilityObj, cloneAbilityObj;

    private const float TIME_UNTIL_ABILITY_READY = 0.0165f;

    /// <summary>
    /// Setting up the ability icons so that only one can
    /// show up after the ability is selected
    /// </summary>
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
            //Disable other ability icons so only the enabled ability is active
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

            //Cool down bar flashing in between 2 colours while in use
            StartCoroutine(cloneCooldownProgress());   
        }
    }

    private IEnumerator boostCooldownProgress()
    {
        //The player has used the boost ability so reset the cooldown bar
        if (playerMovement.isSpeedBoostReady())
        {
            boostCooldownBar.fillAmount = 0;
        }
        else
        {
            //Fill up the boostbar cooldown at a specified amount of rate (time)
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
        while (cloneController.getCloneControl().enabled)
        {
            cloneCooldownBar.fillAmount = 1;
            cloneCooldownBar.color = new Color(253 / 255f, 149 / 255f, 0);
            yield return new WaitForSeconds(0.5f);
            cloneCooldownBar.color = Color.clear;
        }
    }
}
