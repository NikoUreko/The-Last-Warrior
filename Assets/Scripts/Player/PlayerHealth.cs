using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    private float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public GameObject gameOverUI;
    public GameObject retryButton;
    public GameObject backButton;

    public bool isDead;

    public Animator deathAnimator;

    // Start is called before the first frame update
    void Start()
{
    // Ambil HP dari GameManager
    if (GameManager.Instance != null)
    {
        health = GameManager.Instance.playerHealth;
    }
    else
    {
        health = maxHealth;
    }
}

    void Awake()
{
    Instance = this;
}

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        
        
    }


    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if(fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    if (GameManager.Instance != null)
        GameManager.Instance.playerHealth = health;

        if (health <= 0)
        {
            PlayerDead();
            isDead = true;
        }
        else
        {
            print("Player Hit");
        }
        lerpTimer = 0f;
    }
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        if (GameManager.Instance != null)
        GameManager.Instance.playerHealth = health;
        
        lerpTimer = 0f;
    }

    public void ResetHealth()
    {
        health = maxHealth;

        isDead = false;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerHealth = maxHealth;
        }

        UpdateHealthUI();
    }

    public void Retry()
   {
    ResetHealth();
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.name);
   }

   public void Back()
   {
    SceneManager.LoadScene("MainMenu");
   }

    private void PlayerDead()
    {
        GetComponent<PlayerLook>().enabled = false;
        GetComponent<PlayerMotor>().enabled = false;
        GetComponent<InputManager>().enabled = false;

        GetComponentInChildren<Weapon>().enabled = false;
        
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //dying animation
        deathAnimator.enabled = true;

        GetComponent<ScreenBlackOut>().StartFade();

        StartCoroutine(ShowGameOverUI());
    }
    
    private IEnumerator ShowGameOverUI()
    {
        yield return new WaitForSeconds(1f);
        gameOverUI.gameObject.SetActive(true);

       yield return new WaitForSeconds(2f);
        retryButton.SetActive(true);
        backButton.SetActive(true);
    }
}
