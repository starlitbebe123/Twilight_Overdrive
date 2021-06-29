using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public float HP;
    public float MaxHP;
    public float MP;
    public float MaxMP;
    public float ATK;
    public float DEF;
    public float MAG;
    public float MPReg;

    public float time;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.1f && MP<MaxMP)
        {
            MP = MP + MPReg;
            time = 0f;
        }
    }

    public void MpPluse()
    {
        if (MP < MaxMP)
        {
            MP = MP + ATK;
            if(MP + ATK> MaxMP)
            {
                MP = MaxMP;
            }
        }
    }
}
