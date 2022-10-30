using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Resource"))
        {
            var resource = collision.gameObject.GetComponent<Resource>();
            if (resource != null)
            {
                switch (resource.ResourceData.Type)
                {
                    case ResourceType.Health:
                        /*if (Health >= maxHealth)
                        {
                            return;
                        }

                        Health += resource.ResourceData.GetAmount();
                        resource.PickUpResource();*/
                        break;
                    /*case ResourceType.Ammo:
                        if (playerWeapon.AmmoFull)
                        {
                            return;
                        }

                        playerWeapon.AddAmmo(resource.ResourceData.GetAmount());
                        resource.PickUpResource();
                        break;*/
                }
            }
        }

    }
}
