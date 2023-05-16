using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private Formulas formulas;

    [SerializeField] private float speed = 1f;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        formulas = new Formulas();
    }

    void Update() {
        Vector3 direction = formulas.Direction(player.position, transform.position);
        transform.position += direction * speed * Time.deltaTime;
    }
}
