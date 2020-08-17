using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float mspd;
    public float rspd;
    public float db = 0.1F;
    Transform playerTransform;
    Rigidbody playerRigid;
    // Start is called before the first frame update
    void Start()
    {
      //playerTransform = GetComponent<Transform>();
      playerRigid = GetComponent<Rigidbody>();
    }

    float DeadBand(float input)
    {
        if(input < db & input > -db)
        {
            return 0F;
        } else
        {
            return input;
        }
    }


    Vector3 rotate(Vector3 vec, float offset)
    {
        float tx = vec.x;
        float tz = vec.z;

        vec.x = tx * Mathf.Cos(offset) - tz * Mathf.Sin(offset);
        vec.z = - tx * Mathf.Sin(offset) + tz * Mathf.Cos(offset);

        return vec;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 mdir = new Vector3(DeadBand(Input.GetAxisRaw("Horizontal")), 0, DeadBand(Input.GetAxisRaw("Vertical")));
        //Debug.Log(mdir.magnitude);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            mspd = 10;
        } else if (Input.GetKey(KeyCode.LeftControl))
        {
            mspd = 2.5F;
        } else
        {
            mspd = 4;
        }

        Vector3 mouse_position = new Vector3(Input.mousePosition.x - Screen.width / 2, 0F, -1*(Input.mousePosition.y - Screen.height / 2));

        // This line not necessary atm because player is centered on screen. May be needed later
        Vector3 rdir = rotate(mouse_position - playerRigid.position, Mathf.PI/2);


        if (rdir.magnitude > 15)
        {
            Quaternion rotation = Quaternion.LookRotation(rdir);
            //Debug.Log(rotation);

            playerRigid.MoveRotation(rotation);
        }

        //playerRigid.MoveRotation(Quaternion.Lerp(playerRigid.rotation, rotation, rspd*Time.deltaTime));



        playerRigid.MovePosition(playerRigid.position + (mdir.normalized) * Time.deltaTime * mspd);

      //float ang = Vector3.Angle(playerRigid.position, Input.mousePosition);

      //rot[1] = ang;

      //playerRigid.MoveRotation(rot);
    }
}
