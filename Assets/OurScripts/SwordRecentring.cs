using System.Runtime.CompilerServices;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class SwordRecentring : MonoBehaviour
{

    [Header("objects")]
    [SerializeField] private GameObject sword;
    [SerializeField] private Rigidbody swordRB;
    [SerializeField] private GameObject swordRestPosition;

    [Header("Forces")]
    [SerializeField] private float startForce;
    [SerializeField] private float currentForce;
    [SerializeField] private float errorMargin;

    
    [Header("Collision handling")]
    [SerializeField] private LayerMask masks;
    [SerializeField] private GameObject lastCollidedObject;

    [SerializeField] private Transform swordEnd;
    [SerializeField] private Vector3 halfExtends;
    public bool swordStuck;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //swordRestPosition.transform.position = sword.transform.position;
        swordRB = gameObject.GetComponent<Rigidbody>();
    }

    /*
    private void recenterObject()
    {
        //Vector3 location = swordRestPosition.transform.position;
        Debug.Log("checking");
        if (Vector3.Distance(sword.transform.position, swordRestPosition.transform.position) >= errorMargin)
        {
            Debug.Log("moving sword");
            //get direction 
            //Vector3 direction = new Vector3(transform.position.x - swordRestPosition.transform.position.x, transform.position.y - swordRestPosition.transform.position.y , transform.position.z - swordRestPosition.transform.position.z ).normalized;
            Vector3 direction = (swordRestPosition.transform.position - transform.position ).normalized;
            Debug.Log(direction);
            swordRB.AddForce(direction * startForce, ForceMode.Force);
            if(sword.transform.position == swordRestPosition.transform.position)
            {
                swordRB.linearVelocity = new Vector3 (0,0,0);
                Debug.Log("stopped");
            }
        }

    }
    */


    private void forceChange(float max, float min)
    {
        float distannce = Vector3.Distance(sword.transform.position, swordRestPosition.transform.position);
        currentForce = Mathf.Lerp(max, min, distannce);
    }


    // Update is called once per frame
    void Update()
    {
        //recenterObject();
        raycastSword();
    }


    private void raycastSword()
    {
        Collider[] colliders = Physics.OverlapBox(swordEnd.transform.position, halfExtends, Quaternion.identity, masks);
        if(colliders.Length > 0 )
        {
            swordStuck = true;
            Debug.Log("stop sword");
            forceMoveBack();
        }
        else
        {
            swordStuck = false;
        }


    }
    private void forceMoveBack()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(swordEnd.position, halfExtends);

    }

}
