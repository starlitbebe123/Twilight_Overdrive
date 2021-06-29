using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZoneEnemyArea : MonoBehaviour
{
    public GameObject objectZone;
    public GameObject objectZoneEnemyCamera;
    public GameObject[] objectMainCamera;
    public GameObject[] ObjectEnemy = new GameObject[3];
    public List<Collider2D> hitList = new List<Collider2D>();

    public Vector3[] createrPosition = new Vector3[]
    { new Vector3(20.00f, -10.00f, 0.00f), new Vector3(20.00f, 0.00f, 0.00f), new Vector3(20.00f, 10.00f, 0.00f) };
    public float createrRadius = 2f;
    public float createrDelayTimeMax = 1.00f;
    public float createrDelayTimer = 0;
    public float timeMax = 3.00f;
    public float timer = 0;
    public int countMaxTotal;
    public int counterTotal;
    public int[] countMax = new int[] { 2, 4, 6 };
    public int[] counter = new int[] { 0, 0, 0 };
    public int[] areaMax = new int[] { 1, 2, 3 };

    public GameObject leftBorder;
    public GameObject rightBorder;

    void Start()
    {
        objectMainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        objectZone = gameObject.transform.parent.gameObject;
        objectZoneEnemyCamera = objectZone.transform.GetChild(1).gameObject;
        ObjectEnemy = ObjectEnemy.ToList().FindAll(x => x != null).ToArray();
        createrDelayTimer = createrDelayTimeMax;
        countMaxTotal = countMax.Sum();
    }

    void FixedUpdate()
    {
        counterTotal = counter.Sum();
        hitList = Physics2D.OverlapBoxAll(transform.position, gameObject.GetComponent<BoxCollider2D>().size, 0, 128).ToList();

        if (timer <= timeMax)
            timer += Time.deltaTime;
        else
        {
            if (createrDelayTimer <= createrDelayTimeMax)
                createrDelayTimer += Time.deltaTime;
            else
            {
                for (int i = 0; i < ObjectEnemy.Length; i++)
                    if (counter[i] < countMax[i] && hitList.Count(hit => hit.name.Replace("(Clone)", string.Empty) == ObjectEnemy[i].name) < areaMax[i])
                    {
                        if (createrDelayTimer == 0 && createrDelayTimeMax != 0)
                            break;
                        Instantiate(ObjectEnemy[i], transform.position + createrPosition[i], Quaternion.identity);
                        createrPosition[i].x = -createrPosition[i].x;
                        createrDelayTimer = 0;
                        counter[i]++;
                    }
            }

            if (counterTotal >= countMaxTotal && hitList.Count == 0)
            {
                Invoke(nameof(ReleaseCamera), timeMax);
                timer = -1;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position + createrPosition[0], createrRadius);
        Gizmos.DrawSphere(transform.position + createrPosition[1], createrRadius);
        Gizmos.DrawSphere(transform.position + createrPosition[2], createrRadius);
        Gizmos.color = new Color(0, 0, 1, 0.2f);
        Gizmos.DrawCube(transform.position, gameObject.GetComponent<BoxCollider2D>().size);
    }

    void ReleaseCamera()
    {
        objectMainCamera[0].GetComponent<Transform>().transform.position = objectZoneEnemyCamera.GetComponent<Transform>().transform.position;

        leftBorder.SetActive(false);
        rightBorder.SetActive(false);
        objectMainCamera[0].GetComponent<Camera>().enabled = true;
        objectZoneEnemyCamera.GetComponent<Camera>().enabled = false;
        objectZoneEnemyCamera.GetComponent<ZoneEnemyCameraControl>().enabled = false;
        gameObject.GetComponent<ZoneEnemyArea>().enabled = false;
    }
}
