using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon[] allWeapons; // Drag semua senjata (pistol, rifle) ke sini
    public int currentWeaponIndex = 0;
    public Weapon currentWeapon;

    void Start()
    {
        SwitchWeapon(0); // Awal pakai weapon ke-0
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0); // Pistol
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1); // Rifle
        }
    }

    public void SwitchWeapon(int index)
    {
        if (index < 0 || index >= allWeapons.Length) return;

        for (int i = 0; i < allWeapons.Length; i++)
        {
            allWeapons[i].gameObject.SetActive(i == index);
        }

        currentWeaponIndex = index;
        currentWeapon = allWeapons[index];
    }
}
