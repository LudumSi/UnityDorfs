using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float spd;
    Transform playerTransform;
    Rigidbody playerRigid;
    // Start is called before the first frame update
    void Start()
    {
      //playerTransform = GetComponent<Transform>();
      playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 dir = new Vector3(0,0,0);
      Vector3 pos;
      Quaternion rot;

      pos = playerRigid.position;
      rot = playerRigid.rotation;

      if(Input.GetKey(KeyCode.D)){
        dir.x++;
      }else if(Input.GetKey(KeyCode.A)){
        dir.x--;
      }

      if(Input.GetKey(KeyCode.W)){
        dir.z++;
      }else if(Input.GetKey(KeyCode.S)){
        dir.z--;
      }

      pos = pos + dir*Time.deltaTime*spd;

      playerRigid.MovePosition(pos);

      float ang = Vector3.Angle(playerRigid.position,Input.mousePosition);

      rot[1] = ang;

      playerRigid.

      playerRigid.MoveRotation(rot);
    }
}
