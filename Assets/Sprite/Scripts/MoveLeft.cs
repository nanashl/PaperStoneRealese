using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private Vector3 pos;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //moves the enemy to the left
        pos = transform.position;
        pos.x -= Time.deltaTime * 5.5f;
        transform.position = pos;
        if (pos.x < 0) Destroy(this.gameObject);
        if (pos.x < 2f)
        {
            //animates once they hit this point.
            anim.SetTrigger("AttackDistanceReached");

        }
    }

}
