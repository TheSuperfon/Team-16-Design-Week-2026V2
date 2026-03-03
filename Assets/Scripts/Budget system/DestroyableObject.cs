using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private BudgetSystem BudgetSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BudgetSystem = FindAnyObjectByType<BudgetSystem>();    
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void breakApart()
    {


    }

}
