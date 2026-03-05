using System.Collections;
using UnityEngine;

public class SetSlashRotate : MonoBehaviour
{
    GameObject DebtOBJ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = new Quaternion(2, 0, 0, 1);
        //Debug.Log(transform.rotation);
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForEndOfFrame();
        transform.rotation = new Quaternion(2, 0, 0, 1);
        DebtOBJ = FindFirstObjectByType<TempDebtTracker>().gameObject;
        DebtOBJ.GetComponent<TempDebtTracker>().IncreaseDebt();

    }

}
