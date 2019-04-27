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
    public int bloodCostPerShot = 5;

    public int meleeBloodRecovery = 10;
    public int meleeDamage = 10;
    public Vector2 meleeHitboxSize = Vector2.one;
    public GameObject meleeHitBox;
    public FiniteTimer meleeCooldown = new FiniteTimer(0, .5f);
    public Transform meleeAttackCenter;
    public LayerMask meleeDamageLayer;

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

        if (!meleeCooldown.isComplete())
            meleeCooldown.updateTimer(Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) {
            shoot(angle);
        }
        if (Input.GetMouseButtonDown(1) && meleeCooldown.isComplete())
        {
            meleeAttack(angle);
        }
    }

    public void shoot(float angle) {
        if (bloodGauge.canCast(bloodCostPerShot))
        {
            Instantiate(bulletPrefab, shootPoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
            bloodGauge.addBlood(-bloodCostPerShot);
        }
    }

    public void meleeAttack(float angle)
    {
        Collider2D[] results = Physics2D.OverlapBoxAll(meleeAttackCenter.position, meleeHitboxSize, angle, meleeDamageLayer);
        for (int i = 0; i < results.Length; i++) {
            Damagable damagee = results[i].GetComponent<Damagable>();
            if (damagee != null) {
                damagee.takeDamage(meleeDamage);
                bloodGauge.addBlood(meleeBloodRecovery);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(meleeAttackCenter.position, meleeHitboxSize);
    }

    public void setRotation(float angle) {     
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
