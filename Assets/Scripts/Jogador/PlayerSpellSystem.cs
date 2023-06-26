using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellSystem : MonoBehaviour
{
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private float spellCooldown = 2f;
    private float currentSpellCooldown = 0f;

    [SerializeField] private Transform castPoint;

    private bool castingMagic = false;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        bool isSpellCastHeldDown = Input.GetKey(KeyCode.E);
        if (!castingMagic && isSpellCastHeldDown && currentSpellCooldown <= 0f)
        {
            CastingSpell();
        }

        if (currentSpellCooldown > 0f)
        {
            currentSpellCooldown -= Time.deltaTime;
        }

        RechargeMana();
    }

    private void CastingSpell()
    {
        castingMagic = true;
        StartCoroutine(CastSpell());

        // Disable player movement during spell casting
        playerMovement.DisableMovement();

        // Set cooldown for spell casting
        currentSpellCooldown = spellCooldown;
    }

    private IEnumerator CastSpell()
    {
        // Place your spell casting logic here
        // For example:
        Debug.Log("Casting Spell");
        yield return new WaitForSeconds(2f); // Replace with your actual spell casting time

        castingMagic = false;
        playerMovement.EnableMovement();
    }

    private void RechargeMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += manaRechargeRate * Time.deltaTime;
            currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
        }
    }
}
