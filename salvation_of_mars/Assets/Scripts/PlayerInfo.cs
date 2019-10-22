using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int level;
    public bool collectedCard;
    public bool abilityUnlock;

    // Start is called before the first frame update
    void Start()
    {
        collectedCard = false;
        abilityUnlock = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
