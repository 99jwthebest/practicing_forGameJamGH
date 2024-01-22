using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudienceAppraisalMeter : MonoBehaviour
{
    public static AudienceAppraisalMeter instance;

    //public int currentHealth;
    //public int maxHealth;
    //public Slider healthSlider;
    //private Coroutine regen;
    //public float regenHealthYieldTime = 3f;
    //public float regenHealthRateTime = .1f;

    // comboBar
    [SerializeField]
    private int maxComboValue = 100;
    [SerializeField]
    private int currentComboValue;
    public Slider comboSlider;
    private Coroutine degenCombo;
    //public int comboNumber;
    //public TextMeshProUGUI comboNumberText;
    //public GameObject comboObj;
    //public int highestCombo;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMaxComboValue(maxComboValue);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxComboValue(int health)
    {
        comboSlider.maxValue = health;
        comboSlider.value = health;

        //comboNumberText.text = "Combo: " + comboNumber;

        //comboObj.SetActive(false);
    }

    public void SetComboValue(int health)
    {
        comboSlider.value = health;
    }

    public void ComboRefillBar(int refillBar)
    {
        //comboNumber++;
        //if (comboNumber > highestCombo)
        //    highestCombo = comboNumber;

        //comboNumberText.text = "Combo: " + comboNumber;
        //comboObj.SetActive(true);

        currentComboValue += refillBar;
        SetComboValue(currentComboValue);

        if (degenCombo != null)
        {
            StopCoroutine(degenCombo);
        }

        degenCombo = StartCoroutine(DegenComboN());

        if (currentComboValue >= maxComboValue)
        {
            currentComboValue = maxComboValue;
        }
        if (currentComboValue <= 0)
        {
            currentComboValue = 0;
        }
    }

    private IEnumerator DegenComboN()
    {
        yield return new WaitForSeconds(3f);

        while (currentComboValue > 0)
        {
            currentComboValue -= maxComboValue / 100;
            SetComboValue(currentComboValue);
            yield return new WaitForSeconds(.1f);
        }

        //comboNumber = 0;
        //comboNumberText.text = "Combo: " + comboNumber;
        //comboObj.SetActive(false);

        degenCombo = null;
    }
    

}
