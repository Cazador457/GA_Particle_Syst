using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MouseColor : MonoBehaviour
{
    /*public Material material;
    public TextMeshProGUI textoRGB;
    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        material= GetComponent<Render>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current = null) return;

        Vector2 MousePos = Mouse.current.position.ReadValue();
        Ray ray=cam.ScreenPointToRay(MousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 local=transform.InverseTransformPoint(hit.point);

            float r = (local.x + 0.5f);
            float g = (local.y + 0.5f);
            float b = (local.z + 0.5f);

            material.SetColor("_Color", color);
            if (textoRGB != null)
            {
                textoRGB.text = $"R:F2{r:F2}G:{g:F2}B:{b:F2}";
            }
        }
    }*/
}
