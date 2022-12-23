using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotakContronller : MonoBehaviour
{
    public float moveSpeed, axisRowHorizontal, axisRowVertical;
    Animator anim;

    Rigidbody rb;

    public GameObject bulletPrefab;
    public Transform point;
    public float speedBullet;


    public float rotateY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateY = transform.eulerAngles.y;
        axisRowHorizontal = Input.GetAxisRaw("Horizontal");
        axisRowVertical = Input.GetAxisRaw("Vertical");

        //transform.Translate(Vector3.right * -moveSpeed * axisRowHorizontal * Time.deltaTime);
        transform.Translate(Vector3.forward * -moveSpeed * axisRowVertical * Time.deltaTime);

        if (axisRowHorizontal > 0)
        {
            transform.Rotate(Vector3.up * 200 * Time.deltaTime);
        }
        if (axisRowHorizontal < 0)
        {
            transform.Rotate(Vector3.down * 200 * Time.deltaTime);
        }

        

        if (Input.GetKeyDown(KeyCode.F))
        {

            transform.eulerAngles = new Vector3(0, rotateY + 180, 0);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * 10;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, point.position, point.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speedBullet, ForceMode.Impulse);
            anim.SetTrigger("Shot");
            print("mouse");
        }

        else if (axisRowHorizontal == 0 && axisRowVertical == 0)
        {
            anim.SetTrigger("Iddle");
            
        }

        else if ( axisRowHorizontal != 0 || axisRowVertical != 0)
        {
            anim.SetTrigger("Run");
        }
    }
}
