using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject[] objectPlayer;
    public Transform player;

    public Vector3 vPlayer;
    public Vector3 vCam;

    [Range(0, 100)]
    public int speed = 5;

    public Vector2 limitX = new Vector2(-430.00f, 490.00f);
    public Vector2 limitY = new Vector2(-2.00f, 53.00f);

    private void Start()
    {
        objectPlayer = GameObject.FindGameObjectsWithTag("Player");
        player = objectPlayer[0].GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Track();
    }

    private void Track()
    {
        //玩家位置，此為相機最終目標位置
        vPlayer = player.transform.position;
        vPlayer.x += 0.0f;
        vPlayer.y += 5.0f;

        //相機於當前幀的所在位置設置
        vCam = this.transform.position;
        vCam = Vector3.Lerp(vCam, vPlayer, speed * Time.deltaTime);
        vCam.x = Mathf.Clamp(vCam.x, limitX.x, limitX.y);
        vCam.y = Mathf.Clamp(vCam.y, limitY.x, limitY.y);
        vCam.z = -18;

        this.transform.position = vCam;
    }
}
