﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeliveryPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<MoonManController>())
        {
            var player = other.GetComponentInParent<MoonManController>();
            int waterCount = player.DeliverWater();
        }
    }
}