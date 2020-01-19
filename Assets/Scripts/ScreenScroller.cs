using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScroller : MonoBehaviour
{
    [SerializeField] float verticalScollingSpeed = 0.1f;
    [SerializeField] float horizontalScollingSpeed = 0.03f;
    Material material;
    Vector2 offSet;

    private void Awake()
    {
        int screenScrollerCount = FindObjectsOfType<ScreenScroller>().Length;
        if (screenScrollerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offSet = new Vector2(horizontalScollingSpeed, verticalScollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offSet * Time.deltaTime;
    }
}
