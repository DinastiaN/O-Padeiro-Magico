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
    [SerializeField] private GameObject spellObject; // Objeto lançado

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
        // Exemplo de código do efeito do feitiço
        Debug.Log("Casting spell from " + castPoint.position);

        // Instanciar o objeto lançado a partir do asset fornecido
        GameObject spell = Instantiate(spellObject, castPoint.position, castPoint.rotation);

        // Adicione aqui o código para configurar o comportamento do objeto lançado, como adicionar força, aplicar dano, etc.

        yield return null;
    }
}
