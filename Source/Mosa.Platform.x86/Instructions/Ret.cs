﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	///
	/// </summary>
	public sealed class Ret : X86Instruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="Ret" /> class.
		/// </summary>
		public Ret()
			: base(0, 0)
		{
		}

		#endregion Construction

		#region Properties

		/// <summary>
		/// Gets the flow control.
		/// </summary>
		/// <value>The flow control.</value>
		public override FlowControl FlowControl { get { return FlowControl.Return; } }

		#endregion Properties

		#region Methods

		/// <summary>
		/// Emits the specified platform instruction.
		/// </summary>
		/// <param name="ctx">The context.</param>
		/// <param name="emitter">The emitter.</param>
		protected override void Emit(InstructionNode node, MachineCodeEmitter emitter)
		{
			emitter.WriteByte(0xC3);
		}

		#endregion Methods
	}
}
