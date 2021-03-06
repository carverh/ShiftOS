﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// Representations the x86 pause instruction.
	/// </summary>
	public sealed class Pause : X86Instruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of <see cref="Pause"/>.
		/// </summary>
		public Pause() :
			base(0, 0)
		{
		}

		#endregion Construction

		#region Methods

		/// <summary>
		/// Emits the specified platform instruction.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="emitter">The emitter.</param>
		protected override void Emit(InstructionNode node, MachineCodeEmitter emitter)
		{
			emitter.WriteByte(0xF3);
			emitter.WriteByte(0x90);
		}

		#endregion Methods
	}
}
