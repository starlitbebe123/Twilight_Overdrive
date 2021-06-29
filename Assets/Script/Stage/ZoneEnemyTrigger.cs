using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneEnemyTrigger : MonoBehaviour
{
    public GameObject objectZone;
    public GameObject objectZoneEnemyArea;
    public GameObject objectZoneEnemyCamera;
    public GameObject[] objectMainCamera;

    public GameObject borderLeft;
    public GameObject borderRight;

    private void Start()
    {
        objectMainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        objectZone = gameObject.transform.parent.gameObject;
        objectZoneEnemyCamera = objectZone.transform.GetChild(1).gameObject;
        objectZoneEnemyArea = objectZone.transform.GetChild(2).gameObject;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            objectMainCamera[0].GetComponent<Camera>().enabled = false;
            objectZoneEnemyCamera.GetComponent<Camera>().enabled = true;
            objectZoneEnemyCamera.GetComponent<ZoneEnemyCameraControl>().enabled = true;
            borderLeft.SetActive(true);
            borderRight.SetActive(true);
            objectZoneEnemyArea.GetComponent<ZoneEnemyArea>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<ZoneEnemyTrigger>().enabled = false;
        }
    }
}
