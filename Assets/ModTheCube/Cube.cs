using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;

    void Start()
    {
        transform.position = new Vector3(0, 3, 0);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
        StartCoroutine(ChangeColors());
    }

    void Update()
    {
        // transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
        RotationCube();
        FlyingCube();
    }

    private bool subindo = true;
    public float velocidade = 2f;
    void FlyingCube()
    {

        if (subindo)
        {
            transform.Translate(Vector3.up * velocidade * Time.deltaTime);

            if (transform.position.y >= 4f)
            {
                subindo = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * velocidade * Time.deltaTime);

            if (transform.position.y <= 2f)
            {
                subindo = true;
            }
        }
    }

    void RotationCube()
    {
        float xAngle = 0.2f;
        float yAngle = 2.0f;
        float zAngle = 0.2f;

        transform.Rotate(
            xAngle,
            yAngle,
            zAngle
        );

        transform.position = new Vector3(
            0f, // X axis position
            transform.position.y,
            transform.position.z
        );
    }

    IEnumerator ChangeColors()
    {
        Color currentColor = Color.red;
        Color nextColor = Color.blue;

        float tempo = 0f;

        while (true)
        {
            tempo += Time.deltaTime;

            float porcentagem = tempo / 2f;

            material.color = Color.Lerp(
                currentColor,
                nextColor,
                porcentagem
            );

            if (tempo >= 2f)
            {
                tempo = 0f;

                currentColor = nextColor;

                if (nextColor == Color.blue)
                {
                    nextColor = Color.green;
                }
                else if (nextColor == Color.green)
                {
                    nextColor = Color.yellow;
                }
                else if (nextColor == Color.yellow)
                {
                    nextColor = Color.red;
                }
                else
                {
                    nextColor = Color.blue;
                }
            }

            yield return null;
        }
    }
}
