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
	public static int ActiveCounter = 0;
	public static int DisposeCounter = 0;
	string _text;

	public Foo()
	{
		Foo.ActiveCounter++;
		_text = "Autofac works " + string.Format("{0}", System.DateTime.Now);
	}

	public string GetMyString()
	{
		return _text;
	}

	public void Dispose()
	{
		Foo.ActiveCounter--;
		Foo.DisposeCounter++;
	}
}

public class Test : MonoBehaviour 
{
	// Use this for initialization
	void Update () {
		using (var scope = DependencyResolver.Container.BeginLifetimeScope())
		{
			var reader = scope.Resolve<IFoo>();
			Text txt = this.GetComponent<Text>();
			txt.text = string.Format("[{0}:{1}] {2}", Foo.ActiveCounter, Foo.DisposeCounter, reader.GetMyString());
		}
	}
}
