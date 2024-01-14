
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CooldownScript : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] GameObject areaSlashUI;
    [SerializeField] GameObject tripleSlashUI;
    [SerializeField] GameObject dashUI;

    public int buffCount;
    public int defaultXLocation;
    public int defaultYLocation;

    public List<GameObject> SkillUI = new List<GameObject>();

    private void Start()
    {
        buffCount = 0;
        defaultXLocation = 310;
        defaultYLocation = 470;
        areaSlashUI.SetActive(false);
        tripleSlashUI.SetActive(false);
        dashUI.SetActive(false);
    }
    public IEnumerator areaSlashCooldown(float length)
    {
        SkillUI.Add(areaSlashUI);
        StartCoroutine(showAreaSlashCooldown(length));
        yield return new WaitForSeconds(length);
        controller.areaSlashBool = true;
    }
    public IEnumerator showAreaSlashCooldown(float length)
    {
        areaSlashUI.GetComponent<RectTransform>().anchoredPosition = new Vector2((defaultXLocation)+ (buffCount*90)
                                                                                    , defaultYLocation);
        buffCount++;
        areaSlashUI.SetActive(true);
        for (int i = (int)length; i > 0; i--)
        {
            areaSlashUI.GetComponentInChildren<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        buffCount--;
        areaSlashUI.SetActive(false);
        handleShift(areaSlashUI);

    }
    public IEnumerator tripleSlashCooldown(float length)
    {
        SkillUI.Add(tripleSlashUI);
        StartCoroutine(showTripleSlashCooldown(length));
        yield return new WaitForSeconds(length);
        controller.tripleSlashBool = true;
    }
    public IEnumerator showTripleSlashCooldown(float length)
    {
        tripleSlashUI.GetComponent<RectTransform>().anchoredPosition = new Vector2((defaultXLocation) + (buffCount * 90)
                                                                                    , defaultYLocation);
        buffCount++;
        tripleSlashUI.SetActive(true);
        for (int i = (int)length; i > 0; i--)
        {
            tripleSlashUI.GetComponentInChildren<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        buffCount--;
        tripleSlashUI.SetActive(false);
        handleShift(tripleSlashUI);
    }

    public IEnumerator dashCooldown(float length)
    {
        SkillUI.Add(dashUI);
        StartCoroutine(showDashCooldown(length));
        yield return new WaitForSeconds(length);
        controller.dashBool = true;
    }
    public IEnumerator showDashCooldown(float length)
    {
        dashUI.GetComponent<RectTransform>().anchoredPosition = new Vector2((defaultXLocation) + (buffCount * 90)
                                                                                    , defaultYLocation);
        buffCount++;
        dashUI.SetActive(true);
        for (int i = (int)length; i > 0; i--)
        {
            dashUI.GetComponentInChildren<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        buffCount--;
        dashUI.SetActive(false);
        handleShift(dashUI);

    }

    public void handleShift(GameObject removeItem)
    {
        for(int i = 0; i < SkillUI.Count; i++)
        {
            if (SkillUI[i] == removeItem)
            {
                SkillUI.RemoveAt(i);
            }
        }
        for (int i = 0; i < SkillUI.Count; i++)
        {
            SkillUI[i].GetComponent<RectTransform>().anchoredPosition = new Vector2((defaultXLocation) + (i * 90)
                                                                                    , defaultYLocation);
        }
    }

}
