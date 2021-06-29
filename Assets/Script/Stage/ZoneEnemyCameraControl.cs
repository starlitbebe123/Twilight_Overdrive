using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEnemyCameraControl : MonoBehaviour
{
    public GameObject objectZone;
    public GameObject objectZoneEnemyCamera;
    public GameObject[] objectMainCamera;

    public Vector3 vZoneFinal = new Vector3(69.00f, 6.00f, -10.00f);        //最終位置
    public Vector3 vZone;                                                   //當前位置

    [Range(0, 100)]
    public int speed = 5;

    public Vector2 limitX = new Vector2(-430.00f, 490.00f);
    public Vector2 limitY = new Vector2(-2.00f, 53.00f);

    private void Start()
    {
        objectMainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        objectZone = gameObject.transform.parent.gameObject;
        objectZoneEnemyCamera = objectZone.transform.GetChild(1).gameObject;

        vZone = objectMainCamera[0].GetComponent<Transform>().transform.position;
        this.transform.position = vZone;
    }

    private void LateUpdate()
    {
        Track();
    }

    private void Track()
    {
        vZone = Vector3.Lerp(vZone, vZoneFinal, speed * Time.deltaTime);
        vZone.x = Mathf.Clamp(vZone.x, limitX.x, limitX.y);
        vZone.y = Mathf.Clamp(vZone.y, limitY.x, limitY.y);
        vZone.z = -18;

        this.transform.position = vZone;
    }
}
