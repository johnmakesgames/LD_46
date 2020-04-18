using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRefilPlatform : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<MoonManController>())
        {
            var player = other.GetComponentInParent<MoonManController>();
            player.Energy++;
        }
    }
}
