using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private PlayerControls _playerControls;

    [SerializeField] private float _energyDelta = 0.2f;
    [SerializeField] private float _energyMaximum = 5f;
    [SerializeField] private float _impulseMultiplier = 1f;

    public float EnergyMaximum { get { return _energyMaximum; } }

    public float Energy { get; private set; } = 0f;

    public bool CollectsEnergy { get; private set; } = false;
    public bool IsAffectingByField { get; private set; } = false;
    public MagneticField Target;

    private void FixedUpdate()
    {
        if (CollectsEnergy)
        {
            Energy += _energyDelta;
            if(Energy > _energyMaximum)
            {
                Energy = _energyMaximum;
            }
        }
        Time.timeScale = 0.6f * (1 - Energy / 5) + 0.4f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<MagneticField>() != null)
        {
            Target = collision.GetComponent<MagneticField>();
            IsAffectingByField = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<MagneticField>() == Target)
        {
            Target = null;
            IsAffectingByField = false;
        }
    }

    public void StartCollectingEnergy(PlayerModes mode)
    {
        if(Energy > 0)
        {
            EndCollectingEnergy(mode);
        }
        CollectsEnergy = true;
    }

    public void EndCollectingEnergy(PlayerModes mode)
    {
        CollectsEnergy = false;
        GetImpulse(mode);
    }

    private void GetImpulse(PlayerModes mode)
    {
        if (Target != null)
        {
            Vector2 direction = transform.position - Target.transform.position;
            direction.Normalize();

            _rigidbody.velocity = Vector2.zero;

            if(Vector2.Dot(direction, Target.transform.up) > (Mathf.Sqrt(3) / 2)) // cos(30*) = sqrt(3)/2
            {
                direction = Target.transform.up;
            }

            Vector2 force = direction * Energy * 100f * Target.Parent.GetMultiplierFromType() * _playerControls.GetMultiplierFromMode(mode);

            force *= _impulseMultiplier;

            _rigidbody.AddForce(force, ForceMode2D.Impulse); //FORCE MODE (ATTRACTOR, REPELLER)
        }
        Energy = 0;
    }
}
