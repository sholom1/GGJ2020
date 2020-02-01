using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSeparateImages : Trigger
{
    public Image Damaged;
    public Image Repaired;

    public void Replace()
    {
        Damaged.enabled = !Damaged.enabled;
        Repaired.enabled = !Damaged.enabled;
    }
}
