using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class popupDamage : MonoBehaviour
{
    // Start is called before the first frame update



    private TextMeshPro m_TextMeshPro;
    private float DisappearTimer;
    private Color textColor;

    private void Awake()
    {
        m_TextMeshPro= transform.GetComponent<TextMeshPro>();
    }

    public void SetUp(float damageAmount, bool crit)
    {
        m_TextMeshPro.text = damageAmount.ToString();
        if (!crit)
        {
            m_TextMeshPro.fontSize= 4.5f;
            textColor = UtilsClass.GetColorFromString("D4B117");
        }
        else 
        {
            m_TextMeshPro.text = damageAmount.ToString() + " Crit";
            m_TextMeshPro.fontSize= 5;
            textColor = UtilsClass.GetColorFromString("FF0008");
        }
        m_TextMeshPro.color = textColor;
        DisappearTimer = .5f;
        
    }

    public static popupDamage Create(Vector3 pos, float DamageAmount, bool isCrit)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.I.pfDamagePopup, pos, Quaternion.identity);
        popupDamage damagePopUp = damagePopupTransform.GetComponent<popupDamage>();
        
        damagePopUp.SetUp(DamageAmount, isCrit);

        return damagePopUp;
    }

    private void Update()
    {
        float yMoveSpeed = .75f;
        transform.position += new Vector3(0, yMoveSpeed) * Time.deltaTime;

        DisappearTimer -= Time.deltaTime;
        if(DisappearTimer < 0f) 
        {
            float disappearSpeed = 5f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            m_TextMeshPro.color = textColor;

            if(textColor.a < 0f)
            {
                Destroy(gameObject);
            }
        }
    }


}
