using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRefilPlatform : MonoBehaviour
{

    private void Start()
    {
        this.gameObject.tag = "EnergyPad";  
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<MoonManController>())
        {
            var player = other.GetComponentInParent<MoonManController>();
            if (player.Energy < 100)
            {
                player.Energy += 0.05f;
            }
        }
    }
}
