using UnityEngine;
using TMPro;

public class TempDebtTracker : MonoBehaviour
{
    TextMeshProUGUI DebtText;
    float debtNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debtNum = 0;
        DebtText = GetComponent<TextMeshProUGUI>();
        DebtText.text = debtNum.ToString();
        DebtText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseDebt()
    {
        debtNum += 10;
        if (debtNum >= 100)
        {
            DebtText.color = Color.red;
        }
        DebtText.text = debtNum.ToString();
    }


}
