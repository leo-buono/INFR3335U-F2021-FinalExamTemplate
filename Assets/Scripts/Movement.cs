using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10f;
    public float rotateSpeed = 10f;
    public Rigidbody player;
    public Joystick leftStick;
    public Joystick rightStick;
    float currentAngle;

    //public PhotonView view;

    // Update is called once per frame
    void Update()
    {
        if(true /*view.IsMine*/)
        {
        Vector2 currSpeed = new Vector2(player.GetComponent<Rigidbody>().velocity.x, player.GetComponent<Rigidbody>().velocity.z);
        Vector3 stickPos = new Vector3(leftStick.Horizontal, 0f, leftStick.Vertical);
        currentAngle = player.transform.rotation.eulerAngles.y;
        if (stickPos.magnitude < 0.5f)
        {
            stickPos = Vector3.zero;
        }
        //This is player movement, now velocity based.... sort of, the y needs to be fixed
        Vector3 move = new Vector3(stickPos.x * speed, player.velocity.y, stickPos.z * speed); 
        move = Quaternion.AngleAxis(currentAngle, Vector3.up) * move; 
        player.velocity = move;
        //I put it on the 
        Vector3 rightStickPos = new Vector3(0f, rightStick.Horizontal, 0f);
        if(rightStickPos.y > 0.25f || rightStickPos.y < 0.25f)
        {
            player.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * rightStickPos.y * Time.deltaTime, Vector3.up);
        }

        // if (Input.GetKeyDown(KeyCode.W) || stickPos.y >= 0.2f)
        // {
        //         player.AddForce(player.rotation * (Vector3.forward * speed), ForceMode.Impulse);
        // }
        // if (Input.GetKeyDown(KeyCode.S) || stickPos.y <= -0.2f)
        // {
        //         player.AddForce(player.rotation * (Vector3.back * speed), ForceMode.Impulse);
        // }
        // if (Input.GetKeyDown(KeyCode.A) || stickPos.x <= -0.2f)
        // {
        //         player.AddForce(player.rotation *  (Vector3.left * speed), ForceMode.Impulse);
        // }
        // if (Input.GetKeyDown(KeyCode.D) || stickPos.x >= 0.2f)
        // {
        //         player.AddForce(player.rotation *  (Vector3.right * speed),ForceMode.Impulse);
        // }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //         player.AddForce(player.rotation *  (Vector3.up * speed),ForceMode.Impulse);
        // }
        //player/camera rotation


        // if (Input.GetKey(KeyCode.Q))
        // {
        //         player.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * Time.deltaTime, Vector3.up);
        // }
        // if (Input.GetKey(KeyCode.E))
        // {
        //         player.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * Time.deltaTime, Vector3.down); 
        // }
        }
    }
}
