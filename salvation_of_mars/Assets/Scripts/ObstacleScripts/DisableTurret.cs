using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTurret : MonoBehaviour
{
    public Shooter turret;
    public bool permanent;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        turret.isActive = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!permanent)
        {
            turret.isActive = true;
        }
    }
}