﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TargetManager
{
	private static Asml-MHS-ModelingProject1::TargetManagement::TargetManager _instance;

	private static Asml-MHS-ModelingProject1::TargetManagement::TargetFileProcessors::FileProcessorFactory _reader_factory;

	public Asml-MHS-ModelingProject2::System::Collections::ObjectModel::ObservableCollection<AbstractTarget> _targets;

	public virtual FileProcessorFactory FileProcessorFactory
	{
		get;
		set;
	}

	public virtual IEnumerable<Target> Target
	{
		get;
		set;
	}

	public static Asml-MHS-ModelingProject1::TargetManagement::TargetManager GetInstance()
	{
		throw new System.NotImplementedException();
	}

	private ~TargetManager()
	{
	}

	public virtual void Dispose()
	{
		throw new System.NotImplementedException();
	}

	protected virtual void Dispose(bool dispose_others)
	{
		throw new System.NotImplementedException();
	}

	private TargetManager()
	{
	}

	public virtual void AddTarget(int new_x, int new_y, int new_z, bool friend, string new_name)
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddTargets(Asml-MHS-ModelingProject1::System::Collections::Generic::List<Target‎> listOfTargets)
	{
		throw new System.NotImplementedException();
	}

	public virtual void LoadFromFile(string fp)
	{
		throw new System.NotImplementedException();
	}

	public virtual void ClearTargetList()
	{
		throw new System.NotImplementedException();
	}

}

