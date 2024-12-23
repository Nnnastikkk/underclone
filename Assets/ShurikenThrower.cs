using System;
using System.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

public class ShurikenThrower : MonoBehaviour
{
    [SerializeField] private float _throwDelay;
    [SerializeField] private Shuriken _shuriken;
    [SerializeField] private int _shurikenCount;

    public event Action OnEnd;

    private void OnEnable()
    {
        StartCoroutine(StartThrowing());
    }

    private void Throw()
    {
        var shuriken = Instantiate(_shuriken, transform.position, transform.rotation);
        shuriken.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-80,-200), Random.Range(120, 180)), ForceMode2D.Force);
    }

    private IEnumerator StartThrowing()
    {
        for (int i = 0; i < _shurikenCount; i++)
        {
            yield return new WaitForSeconds(_throwDelay);
            Throw();
        }

        OnEnd?.Invoke();
    }
}
