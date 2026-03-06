using UnityEngine;
using TMPro;

public class TempDebtTracker : MonoBehaviour
{
    TextMeshProUGUI DebtText;
    float debtNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debtNum = 1000;
        DebtText = GetComponent<TextMeshProUGUI>();
        DebtText.text = debtNum.ToString();
        DebtText.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseDebt()
    {
        debtNum -= 10;
        if (debtNum <= 700)
        {
            if (debtNum <= 300)
            {
                DebtText.color = Color.red;
            }
            else
            {
                DebtText.color = Color.yellow;
            }


        }
        DebtText.text = debtNum.ToString();
    }


}
