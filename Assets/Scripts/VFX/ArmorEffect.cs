using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorEffect : MonoBehaviour
{
    [SerializeField] private int maxArmor = 100;
    [SerializeField] private Renderer armorMaterial;

    private MaterialPropertyBlock m_PropetyBlock;
    private int currentArmor;

    private void Start()
    {
        m_PropetyBlock = new MaterialPropertyBlock();
        currentArmor = 0;
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        VFXManager.OnArmorTriggrt += TriggerArmor;
    }

    private void OnDisable()
    {
        VFXManager.OnArmorTriggrt -= TriggerArmor;
    }




    void TriggerArmor()
    {
        Debug.Log("aaaaaaaaaa");
        //The propety Value statrs with -1, when the value is 0, armor disappears
        //step 1, stop rolling effect
        m_PropetyBlock.SetFloat("_T_ScrollSpeed", 0f);
        m_PropetyBlock.SetFloat("_HealthC", 1f);

       

        //Debug.Log(m_PropetyBlock.GetFloat("_HealthC"));
        for (int i = 1; i <= maxArmor; i++)
        {

          
            DamageArmor(i * 10);
            
            //step 2 damage the armor 
               //HealthC startas with 1 and armor disappears when the value is 0 (min 0, max 1, default 1)
            m_PropetyBlock.SetFloat("_HealthC", Mathf.Lerp( m_PropetyBlock.GetFloat("_HealthC"), (float)((maxArmor-currentArmor) / maxArmor), Time.deltaTime));
            //Debug.Log(m_PropetyBlock.GetFloat("_HealthC"));
            armorMaterial.SetPropertyBlock(m_PropetyBlock);

        }
      
        



    }

    private void DamageArmor(int dmg)
    {
        SetArmor(Mathf.Min(dmg, 100));
    }
    private void SetArmor(int value)
    {
        currentArmor = value;
    }
}
