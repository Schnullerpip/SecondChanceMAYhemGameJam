using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : AInteractable
{
    public override void Interact()
    {
        TimeShifter.Instance.SpeedUp();
        print("Button Pressed!");
        gameObject.GetComponent<Animator>().SetTrigger("Pressed");
        gameObject.GetComponent<Sender>().TriggerReceivers();
        gameObject.GetComponent<AudioSource>().Play();
    }
}
