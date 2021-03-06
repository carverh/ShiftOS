﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.MosaTypeSystem;
using System;

namespace Mosa.Compiler.Framework.CIL
{
	/// <summary>
	///
	/// </summary>
	public sealed class RefanyvalInstruction : UnaryInstruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="RefanyvalInstruction"/> class.
		/// </summary>
		/// <param name="opcode">The opcode.</param>
		public RefanyvalInstruction(OpCode opcode)
			: base(opcode)
		{
		}

		#endregion Construction

		#region Methods

		/// <summary>
		/// Decodes the specified instruction.
		/// </summary>
		/// <param name="ctx">The context.</param>
		/// <param name="decoder">The instruction decoder, which holds the code stream.</param>
		public override void Decode(InstructionNode ctx, IInstructionDecoder decoder)
		{
			// Decode base classes first
			base.Decode(ctx, decoder);

			// Retrieve a type reference from the immediate argument
			// FIXME: Limit the token types
			var token = (MosaType)decoder.Instruction.Operand;

			throw new NotImplementedException();
		}

		/// <summary>
		/// Validates the instruction operands and creates a matching variable for the result.
		/// </summary>
		/// <param name="ctx">The context.</param>
		/// <param name="compiler">The compiler.</param>
		public override void Resolve(Context ctx, BaseMethodCompiler compiler)
		{
			base.Resolve(ctx, compiler);

			// Make sure the base is a typed reference
			throw new NotImplementedException();
			/*
				if (!Object.ReferenceEquals(_operands[0].Type, MetadataTypeReference.FromName(compiler.Assembly.Metadata, @"System", @"TypedReference")))
				{
					Debug.Assert(false);
					throw new InvalidProgramException(@"Invalid stack object.");
				}

				// Push the loaded value
				_results[0] = CreateResultOperand(_typeRef);
			 */
		}

		#endregion Methods
	}
}
