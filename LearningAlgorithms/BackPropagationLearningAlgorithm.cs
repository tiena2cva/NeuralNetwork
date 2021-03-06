﻿using NeuralNetwork.Lists;

namespace NeuralNetwork.LearningAlgorithms
{
	public class BackPropagationLearningAlgorithm : LearningAlgorithm
	{
		#region Properties
		/// <summary>
		/// Nuy param of Back Propagation Learning Algorithm
		/// </summary>
		protected double _nuy = 0.5;

		/// <summary>
		/// 
		/// </summary>
		protected double _beta = 0.5;

		/// <summary>
		/// Get/set nuy param of Back Propagation Learning Algorithm
		/// </summary>
		public double Nuy
		{
			get { return _nuy; }
			set { _nuy = (value > 0) ? value : _nuy; }
		}

		public double Beta
		{
			get { return _beta; }
			set { _beta = (value > 0) ? value : _beta; }
		}
		#endregion

		#region Construction
		public BackPropagationLearningAlgorithm() : base()
		{

		}
		public BackPropagationLearningAlgorithm(NNetwork nn) : base(nn)
		{
		}
		#endregion

		#region Method
		/// <summary>
		/// To train the neuronal network on data.
		/// inputs[n] represents an input vector of the neural network and expected_outputs[n] the expected ouput for this vector.
		/// </summary>
		public override void Learn()
		{
			do
			{
				LearnStep();
			} while (Iter < MaxIteration && this.Error > ErrorThreshold);
		}

		/// <summary>
		/// Step by step
		/// </summary>
		public override void LearnStep()
		{
			this.Error = 0;
			for (int i = 0; i < Inputs.Count; i++)
			{
				NN.InputLayer = Inputs[i];

				double err = Per.Error(NN.Outputs, Outputs[i]);

				this.Error += err;

				ComputeDelta();
				setWeight();
			}
			this.Error /= Outputs.Count;
			Iter++;
		}

		/// <summary>
		/// Compute Delta param
		/// </summary>
		void ComputeDelta()
		{
			int l = NN.N_Layers - 1;

			// for output layer
			for(int i = 0; i < NN.N_Outputs; i++)
			{
				Neuron n = (Neuron)NN[l][i];
				n.Delta = n.OutputPrime * Per.Err[i];
			}

			// for other layer
			for (l--; l > 0; l--)
			{
				for (int j = 0; j < NN[l].N_Neurons; j++)
				{
					double sk = 0;
					for (int k = 0; k < NN[l + 1].N_Neurons; k++)
					{
						Neuron n = (Neuron)NN[l + 1][k];
						sk += n.Delta * n[j].Weight;
					}
					Neuron nn = (Neuron)NN[l][j];
					nn.Delta = nn.OutputPrime * sk;
				}
			}
		}

		/// <summary>
		/// Set new value of weight for every Axon
		/// </summary>
		void setWeight()
		{
			for (int i = 1; i < NN.N_Layers; i++)
			{
				Layer layer = NN[i];
				for(int j = 0; j < layer.N_Neurons; j++)
				{
					Neuron neuron = (Neuron)layer[j];
					foreach(Axon ax in neuron)
					{
						ax.Delta = _nuy * neuron.Delta * ax.InputNeuron.Value + _beta* ax.Delta;
						ax.Weight += ax.Delta ;
					}
				}
			}
		}
		#endregion
	}
}
