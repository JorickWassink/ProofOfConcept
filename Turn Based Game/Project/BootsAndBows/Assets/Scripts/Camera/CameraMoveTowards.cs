using UnityEngine;

public class CameraMoveTowards : MonoBehaviour
{
    //PLACE SCRIPT NOT ON THE OBJECT YOU WANT TO MOVE TOWARDS BUT PLACE IT ON A CHILD OBJECT WHOSE ONLY PURPOSE IS TO HOLD THE SCRIPT
    Rigidbody2D rb;
    Camera cam;
    float speed = 20;
    Transform target;
    
    void Start()
    {
        cam = FindAnyObjectByType<Camera>();
        rb = cam.gameObject.GetComponent<Rigidbody2D>();
        target = gameObject.transform;
        
    }

    private void Update()
    { 
        target.position = new Vector3 (target.position.x,target.position.y,cam.transform.position.z);
        cam.transform.position = Vector3.Lerp(cam.transform.position, target.transform.position, Time.deltaTime * speed);

        if (cam.transform.position == new Vector3(target.position.x, target.position.y, cam.transform.position.z))
        {
            Destroy(this.gameObject);
        }
    }
}
