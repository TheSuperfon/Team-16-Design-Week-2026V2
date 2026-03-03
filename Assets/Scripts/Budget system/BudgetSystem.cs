using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BudgetSystem : MonoBehaviour
{
    [SerializeField] private int budget;
    [SerializeField] private TextMeshProUGUI uiBudgetElement;
    [SerializeField] private int startingBudget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        budget = startingBudget ;
    }


    public void deductBudget(int value)
    {
        budget -= value;

    }

    public void increaseBudget(int value)
    {
        budget += value;
    }




    // Update is called once per frame
    void Update()
    {
        uiBudgetElement.text = budget.ToString();
    }
}
