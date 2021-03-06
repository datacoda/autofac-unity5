﻿using UnityEngine;
using System.Collections;
using Autofac;


public class DependencyResolver
{
	public static IContainer Container {get; set;}
}


public class Bootstrap : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		var builder = new ContainerBuilder();
		builder.RegisterType<Foo>().As<IFoo>();
		builder.RegisterType<Bar>();
		builder.RegisterType<Baz>();
		builder.RegisterType<Baz.Factory>();
		DependencyResolver.Container = builder.Build();
	}
}
