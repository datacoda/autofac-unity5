using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Autofac;

public interface IFoo
{
	string GetMyString();
}

public class Foo : IFoo, System.IDisposable
{
	string _text;

	public Foo()
	{
		_text = "Autofac works " + string.Format("{0}", System.DateTime.Now);
	}

	public string GetMyString()
	{
		return _text;
	}

	public void Dispose()
	{
		Debug.Log("Disposing");
		DisposeCounter.CurrentCount++;
	}
}

public class DisposeCounter
{
	public static int CurrentCount = 0;
}

public class Test : MonoBehaviour 
{
	// Use this for initialization
	void Update () {
		using (var scope = DependencyResolver.Container.BeginLifetimeScope())
		{
			var reader = scope.Resolve<IFoo>();
			Text txt = this.GetComponent<Text>();
			txt.text = string.Format("[disposed {0}] {1}", DisposeCounter.CurrentCount, reader.GetMyString());
		}
	}
}
