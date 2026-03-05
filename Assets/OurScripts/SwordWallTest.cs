using UnityEngine;

public class SwordWallTest : MonoBehaviour
{
    //instantiate
    public GameObject SlashMetal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        MyCollisions();
    }


    void MyCollisions()
    {
        // Use the OverlapBox to detect if there are any other colliders within this box area.
        // Use the GameObject's center, half the size (as a radius), and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 4, gameObject.transform.rotation);
        int i = 0;
        // Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            // Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            // Increase the number of Colliders in the array
            i++;
        }
    }

    // Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (Application.isPlaying)
            // Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }


    public void InstantMetal()
    {



    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.contacts[0].point);


    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("stay");
    }

}
