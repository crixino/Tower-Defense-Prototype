using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;

    [SerializeField]
    private float updateSpeedSeconds = .2f;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponentInParent<Health>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void Start()
    {
        foregroundImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        if(!foregroundImage.enabled)
            foregroundImage.enabled = true;

        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        while(elapsed < updateSpeedSeconds)
        {
            
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
