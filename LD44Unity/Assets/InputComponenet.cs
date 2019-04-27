using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponenet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed = 5;
    public GameObject bulletPrefab;
    public Transform shootPoint;

    public BloodGauge bloodGauge;
    public MeleeAttack meleeAttack;

    public BloodSpell curSpell;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bloodGauge = GetComponent<BloodGauge>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputDir = new Vector2( Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        rb.velocity = inputDir * speed;

        Vector2 faceDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(faceDir.y, faceDir.x) * Mathf.Rad2Deg;
        setRotation(angle);

        if (Input.GetMouseButtonDown(0)) {
            shoot(angle);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (meleeAttack.canUse(bloodGauge.CurAmount)) {
                int cost = 0;
                int recovery = 0;
                meleeAttack.use(angle, out cost, out recovery);
                bloodGauge.addBlood(-cost + recovery);
            }
        }
    }

    public void shoot(float angle) {
        if (curSpell.canUse(bloodGauge.CurAmount)) {
            int cost = 0;
            int recovery = 0;
            curSpell.use(angle, out cost, out recovery);
            bloodGauge.addBlood(-cost + recovery);
        }      
    }
 

    public void setRotation(float angle) {     
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
