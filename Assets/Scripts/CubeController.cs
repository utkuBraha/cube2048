using System.Collections;
using ChainCube.Scripts.Utils;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    public GameObject Cube
    {
        get => cube;
        set
        {
            if (cube == value)
                return;

            cube = value;
            Inject();
        }
    }
    private IDependency<GameObject>[] dependencies;
    private void Start()
    {
        dependencies = GetComponents<IDependency<GameObject>>();

        if (cube != null)
            Inject();
    } 
    private void Inject()
    {
        foreach (var dependency in dependencies)
        {
            dependency.Inject(Cube);
        }
    }
}