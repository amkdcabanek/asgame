

using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class PlayerHealth : MonoBehaviour
{
    private float lerpTimer;
    public float maxHealth = 100;
    public float health;
    private float chipSpeed = 0.05f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;


    // Start is called before the first frame update
    void Start()
    {
       health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        UpdateHealthUI();
            

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
      
    }
    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {

            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.yellow;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);

        }  

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }
}
