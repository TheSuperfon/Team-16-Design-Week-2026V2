using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class SwordDamageTest1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<string> lastDamagedGoods = new List<string>();
    public TextMeshProUGUI DebtText;
    public float debtNum;

    void Start()
    {
        debtNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DebtText.text = debtNum.ToString();
        if (debtNum >= 100)
        {
            DebtText.color = Color.red;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if list number . list.length.name == collision then do not add
        //else
        //if list length not over 5
        //just add to list
        //else then remove the 1st one and add this one

        Debug.Log("Why");

        lastDamagedGoods.Add(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("lie");
        lastDamagedGoods.Add(other.gameObject.name);
        debtNum += 10;
        
    }

}
