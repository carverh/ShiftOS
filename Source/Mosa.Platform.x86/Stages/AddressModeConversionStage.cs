// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;
using System;
using System.Collections.Generic;

namespace Mosa.Platform.x86.Stages
{
	/// <summary>
	///
	/// </summary>
	public sealed class AddressModeConversionStage : BaseTransformationStage
	{
		protected override void PopulateVisitationDictionary()
		{
			// Nothing to do
		}

		protected override void Run()
		{
			foreach (var block in BasicBlocks)
				for (var node = block.First; !node.IsBlockEndInstruction; node = node.Next)
					if (!node.IsEmpty)
						if (node.OperandCount == 2 && node.ResultCount == 1)
							ThreeTwoAddressConversion(node);
		}

		/// <summary>
		/// Converts the given instruction from three address format to a two address format.
		/// </summary>
		/// <param name="node">The conversion context.</param>
		private void ThreeTwoAddressConversion(InstructionNode node)
		{
			var instruction = node.Instruction as X86Instruction;

			if (instruction == null)
				return;

			if (!instruction.ThreeTwoAddressConversion)
				return;

			if (!(node.OperandCount >= 1 && node.ResultCount >= 1 && node.Result != node.Operand1))
				return;

			Operand result = node.Result;
			Operand operand1 = node.Operand1;

			node.Operand1 = result;

			var move = GetMove(result, operand1);
			var size = GetInstructionSize(result.Type);

			var newNode = new InstructionNode(move, result, operand1);
			newNode.Size = size;
			node.Previous.Insert(newNode);

			return;
		}
	}
}
