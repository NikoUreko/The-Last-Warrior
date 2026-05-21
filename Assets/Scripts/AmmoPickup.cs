using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Weapon playerWeapon = other.GetComponentInChildren<Weapon>();
            if (playerWeapon != null)
            {
                playerWeapon.currentReserveAmmo += ammoAmount;

                // Maksimum cadangan tidak boleh melebihi batas
                if (playerWeapon.currentReserveAmmo > playerWeapon.maxReserveAmmo)
                {
                    playerWeapon.currentReserveAmmo = playerWeapon.maxReserveAmmo;
                }
                Destroy(gameObject); 
            }
        }
    }
}
