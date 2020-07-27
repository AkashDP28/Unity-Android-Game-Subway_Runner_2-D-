using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroll : MonoBehaviour
{
    public float ScrollSpeed;// = -0.25f;
    private MeshRenderer Mesh_Renderer;

    public static BGscroll instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Mesh_Renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!GameManager.instance.IsPlayerDead)
        {
            Scroll();
        }
    }
    void Scroll()
    {
        Vector2 OffSet = Mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        OffSet.x -= Time.deltaTime * ScrollSpeed;
        Mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", OffSet);

    }
}
