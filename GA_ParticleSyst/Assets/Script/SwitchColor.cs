using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchColor : MonoBehaviour
{
    public Material material;
    public float speed = 1.0f;

    private float r = 0.5f;
    private float g = 0.5f;
    private float b = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        /*if (Input.GetKey(KeyCode.R)) r += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.F)) r -= speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.G)) g += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.H)) g -= speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.B)) b += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.N)) b -= speed * Time.deltaTime;*/

        if (Keyboard.current == null) return;
        if(Keyboard.current.rKey.isPressed) r += speed * Time.deltaTime;
        if( Keyboard.current.fKey.isPressed) r -= speed * Time.deltaTime;

        if (Keyboard.current.gKey.isPressed) g += speed * Time.deltaTime;
        if (Keyboard.current.hKey.isPressed) g -= speed * Time.deltaTime;

        if (Keyboard.current.bKey.isPressed) b += speed * Time.deltaTime;
        if (Keyboard.current.nKey.isPressed) b -= speed * Time.deltaTime;

        r = Mathf.Clamp01(r);
        g = Mathf.Clamp01(g);
        b = Mathf.Clamp01(b);

        material.SetColor("_Color", new Color(r, g, b,1.0f));
    }
}
