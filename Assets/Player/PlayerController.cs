using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float linear_speed;
    public float rotation_speed;

    public int healthPoints = 80;
    public int maxHealthPoints = 100;

    public int woodCollected = 0;
    public int ropeCollected = 0;
    public int fabricCollected = 0;

    public GameObject bulletPrefab; // assign your bullet prefab in the Inspector
    public GameObject GameOverMenuUI;
    public float bullet_speed;

    Vector2 movementInput;
    private Rigidbody2D rb;

    public Boat boat;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerPrefs.DeleteAll();

        boat = GameObject.FindGameObjectWithTag("Boat").GetComponent<Boat>();

    }

    private void Update()
    {
        float distanceToBoat = getDistanceToBoat();

        if (distanceToBoat < 10f)
        {
            if (!boat.isDiscovered)
            {
                boat.isDiscovered = true;

                Debug.Log("Barco encontrado!");

                GameObject dialogBox = GameObject.FindGameObjectWithTag("DialogBox");
                dialogBox.GetComponent<DialogBehaviour>().showMessage("Parece que isto aqui era um barco...\nEstá bastante averiguado, mas posso encontrar recursos pela ilha para consertá - lo!");

            }

            GameObject repairDialogBox = GameObject.FindGameObjectWithTag("RepairText");
            repairDialogBox.GetComponent<DialogBehaviour>().showMessage("Tecle E para reparar");

        }


    }

    private void FixedUpdate()
    {

        if (movementInput != Vector2.zero)
        {
            GetComponent<Animator>().SetBool("Andando", true);
            rb.MovePosition(rb.position + movementInput * linear_speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            GetComponent<Animator>().SetBool("Andando", false);
        }
        Rotate();
        if (healthPoints <= 0)
        {
            GameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;

        }
}

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire(InputValue clickValue)
    {
        GetComponent<Animator>().SetTrigger("Tiro");

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Quaternion playerRotation = transform.rotation;
        Vector3 offset = playerRotation * new Vector3(0.5f, -0.5f, 0f); // adjust the offset as needed
        Vector3 direction = mousePosition - (offset + transform.position);
        direction.z = 0f;
        direction.Normalize();

        // Create a new bullet instance and set its position and rotation
        GameObject bullet = Instantiate(bulletPrefab, (transform.position + offset), Quaternion.identity);
        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Shoot the bullet in the direction of the mouse cursor
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction * bullet_speed;
    }


    void Rotate()
    { // essa eh na conta do GPT
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Quaternion playerRotation = transform.rotation;
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void increaseHealthPoints(int amount)
    {
        if (healthPoints + amount > maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }
        else
        {
            healthPoints += amount;
        }
    }

    public float getDistanceToBoat()
    {
        return Vector2.Distance(transform.position, boat.transform.position);
    }
}
