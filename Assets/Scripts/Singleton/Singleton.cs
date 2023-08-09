using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
private static T _instance;

//싱글턴을 상속받은 클래스의 인스턴스 참조 및 생성을 위한 프로퍼티
public static T Instance
{
    get
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                GameObject obj = new GameObject { name = typeof(T).Name };
                _instance = obj.AddComponent<T>();
            }
        }

        return _instance;
    }
}


/// <summary>
///싱글턴을 상속받은 클래스가 초기화할 때,초기화 된 자신의 인스턴스가 이미 있는지 확인 후,
///이미 있다면,단일 인스턴스 보장을 위해 자신을 파괴(Destroy)한다.
///따라서 씬에는 한번에 하나의 특정한 싱글턴 인스턴스가 있다. 두개를 추가하려고 하면 하나는 자동으로 제거된다.
/// </summary>
public virtual void Awake()
{
    if (_instance == null)
    {
        _instance = this as T;
        DontDestroyOnLoad(gameObject);
    }
    else
        Destroy(gameObject);
}
}