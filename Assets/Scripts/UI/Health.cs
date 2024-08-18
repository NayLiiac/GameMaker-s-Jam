using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public List<GameObject> Hearts = new List<GameObject>();

    [field: SerializeField]
    [Range(0, 10)]
    public int HealthPoints;
    public int _maxHealth { get; private set; }

    private void Start()
    {
        _maxHealth = HealthPoints;
    }

    public void SetHealth(int health)
    {
        if (health != 0)
        {
            if (_maxHealth != health)
            {
                HealthPoints = health;
                int heartToDeactivate = Hearts.Count;

                for (int i = 0; i < heartToDeactivate; i++)
                {
                    Hearts[i].SetActive(false);
                }

                for (int i = 0; i < HealthPoints; i++)
                {
                    Hearts[i].SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < _maxHealth; i++)
                {
                    Hearts[i].SetActive(true);
                }
            }
        }
        else
        {
            // haha you dead
            HealthPoints = health;
            for (int i = 0; i < Hearts.Count; i++)
            {
                Hearts[i].SetActive(false);
            }
            GameManager.Instance.GameLost = true;
        }
    }
}
