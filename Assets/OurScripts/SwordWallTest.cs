using System.Collections;
using UnityEngine;

public class SwordWallTest : MonoBehaviour
{
    //instantiate
    public GameObject SlashMetal;
    float isSlashed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSlashed = 0; //not slashed
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("why");
            


        }

        //MyCollisions();
    }


    


    public void InstantMetal()
    {



    }

    


    private void OnTriggerEnter(Collider other)
    {
        //if thing is rotated 90 degrees y
        if (isSlashed == 0)
        {
            if (other.GetComponent<MeshCollider>() != null)
            {
                /*Debug.Log(other.gameObject.GetComponent<Collision>().contacts[0].point);
                Vector3 DecalPos = other.gameObject.GetComponent<Collision>().contacts[0].point;

                Instantiate(SlashMetal, DecalPos, Quaternion.identity);*/
                Vector3 collisionPoint = other.ClosestPoint(transform.position);
                //Debug.Log(collisionPoint.ToString());
                if (other.transform.rotation.y == 90) // wall
                {
                    Instantiate(SlashMetal, collisionPoint + new Vector3(0, 0, 0), Quaternion.identity); //make rotate 90 degrees via x for ground
                }
                else
                {
                    Instantiate(SlashMetal, collisionPoint + new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)); //make rotate 90 degrees via x for ground
                }
                
                isSlashed = 1;

            }


        }
        if (isSlashed == 1)
        {
            isSlashed = 2;
            StartCoroutine(timeTillNextSlash());

        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (isSlashed == 0)
        {
            if (other.GetComponent<MeshCollider>() != null)
            {
                /*Debug.Log(other.gameObject.GetComponent<Collision>().contacts[0].point);
                Vector3 DecalPos = other.gameObject.GetComponent<Collision>().contacts[0].point;

                Instantiate(SlashMetal, DecalPos, Quaternion.identity);*/
                Vector3 collisionPoint = other.ClosestPoint(transform.position);
                Debug.Log(collisionPoint.ToString());
                Instantiate(SlashMetal, collisionPoint + new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)); //make rotate 90 degrees via x for ground
                isSlashed = 1;

            }
            if (isSlashed == 1)
            {
                isSlashed = 2;
                StartCoroutine(timeTillNextSlash());

            }

        }
    }


    public IEnumerator timeTillNextSlash()
    {
        yield return new WaitForSeconds(2);
        isSlashed = 0;
    }

}
