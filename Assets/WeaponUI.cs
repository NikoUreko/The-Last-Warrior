using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image weaponIcon;
    public Sprite pistolSprite;
    public Sprite rifleSprite;

    public WeaponManager weaponManager;

    void Update()
    {
        if (weaponManager == null || weaponManager.currentWeapon == null) return;

        Weapon.WeaponModel model = weaponManager.currentWeapon.thisWeaponModel;

        switch (model)
        {
            case Weapon.WeaponModel.Handgun:
                weaponIcon.sprite = pistolSprite;
                break;
            case Weapon.WeaponModel.Rifle:
                weaponIcon.sprite = rifleSprite;
                break;
        }
    }
}
