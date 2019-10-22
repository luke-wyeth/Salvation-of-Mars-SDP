using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{ 
    public PlayerInfo playerInfo, cloneInfo;
    public Animator alarmAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfo.collectedCard || cloneInfo.collectedCard)
        {
            alarmAnimator.SetBool("isTriggered", true);
        }
    }
}
