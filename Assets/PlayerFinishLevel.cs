using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinishLevel : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private List<MonoBehaviour> _componentsToDisable;

    public void FinishLevel(Vector2 position)
    {
        Vector2 direction = (Vector2)transform.position - position;
        float angle = Vector2.Angle(transform.right, direction);
        if(direction.y < 0) 
            transform.Rotate(new Vector3(0, 0, angle));
        else 
            transform.Rotate(new Vector3(0, 0, -angle));

        _rigidbody.simulated = false;
        _collider.enabled = false;
        //transform.position = finishBlock.transform.position;

        foreach(var component in _componentsToDisable)
        {
            component.enabled = false;
        }

        float animationTime = _playerAnimation.FinalAnimation();
        StartCoroutine(DelayedExecution(animationTime, position));
    }

    IEnumerator DelayedExecution(float time, Vector2 position)
    {
        for(float t = 0; t < time; t += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(transform.position, position, 0.05f);
            yield return null;
        }       

        gameObject.SetActive(false);
    }
}
