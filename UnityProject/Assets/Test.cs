using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Autofac;

public interface IFoo
{
	string GetMyString();
}

public class Foo : IFoo
	{
	public string GetMyString()
	{
		return "Autofac works!";
	}
}

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		using (var scope = DependencyResolver.Container.BeginLifetimeScope())
		{
			var reader = scope.Resolve<IFoo>();
			Text txt = this.GetComponent<Text>();
			txt.text = reader.GetMyString();
		}
	}
}
