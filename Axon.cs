﻿using System;

namespace NeuralNetwork.Lists
{
	public class Axon : IElement
	{
		#region Properties
		public double Weight { set; get; }
		public Neuron OutputNeuron { set; get; }
		public IInputValue InputNeuron { set; get; }
		public string Id { get; set; }

		public double Value
		{
			get
			{
				return Weight * InputNeuron.Value;
			}
		}
		
		/// <summary>
		/// Delta parameter for BackPropagation
		/// </summary>
		public double Delta
		{
			get; set;
		}
		#endregion

		#region Construction
		Axon(string Id)
		{
			this.Id = Id;
			Delta = 0;
		}
		Axon(string Id, IInputValue input, Neuron output) : this(Id)
		{
			InputNeuron = input;
			OutputNeuron = output;
		}
		public Axon(string Id, Random rand) : this(Id)
		{
			Weight = rand.NextDouble() * 2 - 1;		// [-1, 1]
		}

		public Axon(string Id, double w) : this(Id)
		{
			Weight = w;
		}

		public Axon(string Id, Random rand, IInputValue input, Neuron output) : this(Id, input, output)
		{
			Weight = rand.NextDouble() * 2 - 1;     // [-1, 1]
		}

		public Axon(string Id, double w, Neuron input, Neuron output) : this(Id, input, output)
		{
			Weight = w;
		}
		#endregion

		#region Method
		/// <summary>
		/// For debug
		/// </summary>
		public string PrintInfo()
		{
			string s = "";
			s += "\t\tAxon ID : " + Id + '\n';
			s += "\t\t\tWeight : " + Weight + '\n';

			return s;
		}
		#endregion
	}
}
