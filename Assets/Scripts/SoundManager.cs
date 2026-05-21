using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource shootingSoundHandgun;
    public AudioSource shootingSoundRifle;

    public AudioSource reloadSoundHandgun;
    public AudioSource reloadSoundRifle;
    
    public AudioClip RifleShot;

    public AudioSource emptyMagazineSoundHandgun;

    public AudioClip enemyShot;
    public AudioClip enemyHurt;
    public AudioClip enemyDead;
    
    public AudioSource enemyChannel;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Handgun:
                shootingSoundHandgun.Play();
                break;
            case WeaponModel.Rifle:
                shootingSoundRifle.PlayOneShot(RifleShot);
                break;
        }
    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Handgun:
                reloadSoundHandgun.Play();
                break;
            case WeaponModel.Rifle:
                reloadSoundRifle.Play();
                break;
        }
    }
}
