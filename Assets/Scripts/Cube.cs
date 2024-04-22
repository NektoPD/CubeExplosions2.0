using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CubeExploder))]
[RequireComponent(typeof(RandomMaterialColorChanger))]
[RequireComponent(typeof(CubeGenerator))]
public class Cube : MonoBehaviour, IPointerClickHandler
{
    private Rigidbody _rigidbody;
    private CubeGenerator _generator;
    private CubeExploder _exploder;
    private int _currentCubeGenarationPossibility = 100;
    private int _minCubeGenrationPossibility = 1;
    private int _maxCubeGenrationPossibility = 101;
    private float _explosionForce = 3;
    private float _explosionRadius = 2;
    private int _scaleDivider = 2;

    private void Awake()
    {
        _exploder = GetComponent<CubeExploder>();
        _rigidbody = GetComponent<Rigidbody>();
        _generator = GetComponent<CubeGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int probability = Random.Range(_minCubeGenrationPossibility, _maxCubeGenrationPossibility);

        if (probability <= _currentCubeGenarationPossibility)
        {
            _generator.GenerateCubes(this);
        }
        else
        {
            _exploder.Explode();
        }

        Destroy(gameObject);
    }

    public void Init()
    {
        transform.localScale /= _scaleDivider;
        _rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        ReduceGenerationPossibilityByHalf();
        _exploder.IncreaseExplosionParameters();
    }

    private void ReduceGenerationPossibilityByHalf()
    {
        _currentCubeGenarationPossibility /= 2;
    }
}
