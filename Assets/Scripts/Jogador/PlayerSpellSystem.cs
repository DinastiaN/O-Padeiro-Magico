using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellSystem : MonoBehaviour
{
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana = 100f;
    [SerializeField] private float rechargeRate = 10f;
    [SerializeField] private float spellCooldown = 1f;
    [SerializeField] private float spellCost = 20f;
    [SerializeField] private Transform castPoint;
    [SerializeField] private GameObject spellObject;
    [SerializeField] private float spellSpeed = 10f; 
    [SerializeField] private float spellDuration = 5f;  
    [SerializeField] private float delay = 1f;

    private bool canCast = true;

    private void Update()
    {
        RechargeMana();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastSpell();
        }
    }

    private void RechargeMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += rechargeRate * Time.deltaTime;
            currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
        }
    }

    public void CastSpell()
    {
        if (canCast && currentMana >= spellCost)
        {
            StartCoroutine(SpellCooldown());
            StartCoroutine(SpellEffect());

            currentMana -= spellCost;
        }
    }

    private IEnumerator SpellCooldown()
    {
        canCast = false;
        yield return new WaitForSeconds(spellCooldown);
        canCast = true;
    }

    private IEnumerator SpellEffect()
    {
        Debug.Log("Casting spell from " + castPoint.position);

        yield return new WaitForSeconds(delay);

        GameObject spell = Instantiate(spellObject, castPoint.position, castPoint.rotation);

        Rigidbody rb = spell.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spell.transform.forward * spellSpeed, ForceMode.Impulse);
        }

        yield return new WaitForSeconds(spellDuration);

        Destroy(spell);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }


}
