using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTextScript : MonoBehaviour
{
    public float timeToLive;
    public float timeElapsed = 0;
    public float floatSpeed;
    public TextMeshProUGUI healthTextMeshPro;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthTextMeshPro.rectTransform.position = new Vector3(
            healthTextMeshPro.rectTransform.position.x,
            healthTextMeshPro.rectTransform.position.y + floatSpeed * Time.deltaTime,
            healthTextMeshPro.rectTransform.position.z
            );
        healthTextMeshPro.alpha = 1 - (timeElapsed / timeToLive);
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
