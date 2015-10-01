﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks
{
	public class Axon
	{
		public double Weight { set; get; }
		public Neuron OutputNeuron { set; get; }
		public Neuron InputNeuron { set; get; }
		public string Id { get; set; }

		#region Construction
		Axon(string Id)
		{
			this.Id = Id;
		}
		Axon(string Id, Neuron input, Neuron output) : this(Id)
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

		public Axon(string Id, Random rand, Neuron input, Neuron output) : this(Id, input, output)
		{
			Weight = rand.NextDouble() * 2 - 1;     // [-1, 1]
		}

		public Axon(string Id, double w, Neuron input, Neuron output) : this(Id, input, output)
		{
			Weight = w;
		}
		#endregion

		/// <summary>
		/// For debug
		/// </summary>
		public void Print()
		{
			Console.WriteLine("\t\tAxon ID : " + Id);
			Console.WriteLine("\t\t\tWeight : " + Weight);
		}
	}
}