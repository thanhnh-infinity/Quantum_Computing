#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.Bell", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs", 162L, 7L, 5L)]
[assembly: OperationDeclaration("Quantum.Bell", "BellTest (count : Int, initial : Result) : (Int, Int)", new string[] { }, "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs", 405L, 19L, 5L)]
#line hidden
namespace Quantum.Bell
{
    public class Set : Operation<(Result,Qubit), QVoid>
    {
        public Set(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<(Result,Qubit), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Bell.Set", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (desired,q1) = _args;
#line 10 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var current = M.Apply<Result>(q1);
#line 11 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    if ((desired != current))
                    {
#line 13 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        MicrosoftQuantumPrimitiveX.Apply(q1);
                    }

#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Bell.Set", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class BellTest : Operation<(Int64,Result), (Int64,Int64)>
    {
        public BellTest(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Quantum.Bell.Set) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get
            {
                return this.Factory.Get<ICallable<(Result,Qubit), QVoid>, Quantum.Bell.Set>();
            }
        }

        public override Func<(Int64,Result), (Int64,Int64)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Bell.BellTest", OperationFunctor.Body, _args);
                var __result__ = default((Int64,Int64));
                try
                {
                    var (count,initial) = _args;
#line 22 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var numOnes = 0L;
#line 23 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var qubits = Allocate.Apply(1L);
#line 25 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 27 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        Set.Apply((initial, qubits[0L]));
#line 28 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        var res = M.Apply<Result>(qubits[0L]);
                        //Count the number of ones we saw:
#line 31 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        if ((res == Result.One))
                        {
#line 33 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                            numOnes = (numOnes + 1L);
                        }
                    }

#line 36 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    Set.Apply((Result.Zero, qubits[0L]));
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = ((count - numOnes), numOnes);
                    //Return number of times we saw a |0 > and number of times we saw a |1>
#line 39 "/Volumes/Workspace_ThanhNH/All_Workspace/Quantum_Programming_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Bell.BellTest", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest, (Int64,Result), (Int64,Int64)>((count, initial));
        }
    }
}