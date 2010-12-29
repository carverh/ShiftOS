﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Fröhlich (grover) <sharpos@michaelruck.de>
 */

using Mosa.Runtime.CompilerFramework;
using Mosa.Runtime.Linker;
using Mosa.Runtime.Metadata.Loader;
using Mosa.Runtime.Vm;
using Mosa.Tools.Compiler.Linkers;
using Mosa.Tools.Compiler.TypeInitializers;

namespace Mosa.Tools.Compiler
{
	public class AotAssemblyCompiler : AssemblyCompiler
	{
		public AotAssemblyCompiler(IArchitecture architecture, ITypeInitializerSchedulerStage typeInitializerSchedulerStage, IAssemblyLinker linker, ITypeSystem typeSystem)
			: base(architecture, typeSystem)
		{
			this.Pipeline.AddRange(
				new IAssemblyCompilerStage[] 
					{
						new TypeLayoutStage(),
						new AssemblyMemberCompilationSchedulerStage(),
						new MethodCompilerSchedulerStage(),
						new TypeInitializerSchedulerStageProxy(typeInitializerSchedulerStage),
						new LinkerProxy(linker)
					});
		}

		public void Run()
		{
			// Build the default assembly compiler pipeline
			Architecture.ExtendAssemblyCompilerPipeline(this.Pipeline);

			// Run the compiler
			Compile();
		}

		/// <summary>
		/// Creates the method compiler.
		/// </summary>
		/// <param name="compilationScheduler">The compilation scheduler.</param>
		/// <param name="type">The type.</param>
		/// <param name="method">The method.</param>
		/// <returns></returns>
		public override IMethodCompiler CreateMethodCompiler(ICompilationSchedulerStage compilationScheduler, RuntimeType type, RuntimeMethod method)
		{
			IMethodCompiler mc = new AotMethodCompiler(
				this,
				compilationScheduler,
				type,
				method
			);
			this.Architecture.ExtendMethodCompilerPipeline(mc.Pipeline);
			return mc;
		}
	}
}