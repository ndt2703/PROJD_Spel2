using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorEffect : MonoBehaviour
{
    [SerializeField] private int maxArmor = 100;
    [SerializeField] private Renderer armorMaterial;

    private MaterialPropertyBlock m_PropetyBlock;
    [SerializeField] private int currentArmor;
    private bool isDamaging;
    private bool timeToGo;
    private float targetDiss;
    private float currentDiss;

    private void Start()
    {
        m_PropetyBlock = new MaterialPropertyBlock();
        currentArmor = 0;
        currentDiss=targetDiss = 1f;
    }
    private void Update()
    {
        if (currentArmor > 0)
            armorMaterial.enabled = true;
        else
            armorMaterial.enabled = false;
        if (isDamaging)
        {
            //the propety health starts with 1, when it is 0, armor disappears (0min,1max,1 default)
            DamageArmor(10);
            //from 1-0,9
            currentDiss = Mathf.Lerp(currentDiss,targetDiss, Time.deltaTime);
            m_PropetyBlock.SetFloat("_HealthC", currentDiss);
            armorMaterial.SetPropertyBlock(m_PropetyBlock);
            if(currentArmor==100 && m_PropetyBlock.GetFloat("_HealthC") <= 0.1f)
            {
                m_PropetyBlock.SetFloat("_HealthC", 0f);
                armorMaterial.SetPropertyBlock(m_PropetyBlock);
                isDamaging = false;
                timeToGo = true;
            
            }
            if (timeToGo)
            {
                Destroy(gameObject);
            }
           
        }
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        VFXManager.OnArmorTriggrt += TriggerArmor;
    }

    private void OnDestroy()
    {
        
        VFXManager.OnArmorTriggrt -= TriggerArmor;
        Debug.Log("Lucky");
    }


    void TriggerArmor()
    {
        Debug.Log("aaaaaaaaaa");
        isDamaging = true;
        //only needs to stop this once
        m_PropetyBlock.SetFloat("_T_ScrollSpeed", 0f);
    }

    public void DamageArmor(int dmg)
    {
        SetArmor(Mathf.Min(currentArmor+dmg, 100));
    }
    public void SetArmor(int value)
    {
        currentArmor = value;
        targetDiss = (float)(maxArmor-currentArmor) / maxArmor;
    }
}
