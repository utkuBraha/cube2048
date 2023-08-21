using System.Collections;
using System.Collections.Generic;
using Cube2048;
using UnityEngine;

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
    public interface IDependency<T> where T : class
    {
        void Inject(T dependency);
    }
}