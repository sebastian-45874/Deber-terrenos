using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f;
    
    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        // Esta es la línea corregida
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1. Rotación sobre el eje Y usando A y D (Eje Horizontal)
        float rot = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rot, 0);

        // 2. Movimiento hacia adelante y atrás usando W y S (Eje Vertical)
        float move = Input.GetAxis("Vertical");
        
        // Calculamos la dirección basándonos en hacia dónde está mirando el cubo
        moveDirection = transform.forward * move;

        // Añadimos una gravedad básica para que el cubo caiga si el terreno baja
        moveDirection.y -= 9.81f * Time.deltaTime;

        // 3. Ejecutamos el movimiento
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}