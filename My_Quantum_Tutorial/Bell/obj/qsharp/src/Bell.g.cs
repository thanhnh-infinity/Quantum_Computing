#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.Bell", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs", 356L, 8L, 5L)]
[assembly: OperationDeclaration("Quantum.Bell", "BellTest (count : Int, initial : Result) : (Int, Int)", new string[] { }, "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs", 1306L, 27L, 5L)]
[assembly: OperationDeclaration("Quantum.Bell", "BellTest_2 (count : Int, initial : Result) : (Int, Int, Int)", new string[] { }, "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs", 3432L, 68L, 5L)]
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
#line 11 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var current = M.Apply<Result>(q1);
#line 12 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    if ((desired != current))
                    {
#line 14 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
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
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Quantum.Bell.Set) };
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

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
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
                    //If you need a variable whose value can changem such as numOnes, declare the variable with mutable keyword
#line 31 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var numOnes = 0L;
                    // Using statement is also special to Q#. It is used to allocate an array of qubits for use in a block of code.
                    // In Q#, all qubits are dynammically allocated and released, rather than being fixed resources. Using statement allocates a set of qubits at the start 
                    // and releases those qubits at the end of the block
#line 36 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var qubits = Allocate.Apply(1L);
#line 38 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 40 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        Set.Apply((initial, qubits[0L]));
                        //Default, variables in Q# are immutable - their values may not changed after they are boud
                        //The let keyword is used to indicate the binding of an immutable variable
                        // Important operation in Quantum
                        // X : Gate to flip a quabit all the way from 0 to 1 or 1 to 0
                        // H : Hadamard Get flip in halfway it means there is a probabilisty to consider value is 0 or 1
                        // ===> this is SUPERPOSITION 
                        // Everytime we measure we ask for a classical value but the qubit is halfway between 0 and 1, so we get probabilistuc 0 half and 1half time.
#line 49 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
#line 50 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        var res = M.Apply<Result>(qubits[0L]);
                        //Count the number of ones we saw:
#line 53 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        if ((res == Result.One))
                        {
                            //The mutable variable's value can be changed using a set statement
#line 56 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                            numOnes = (numOnes + 1L);
                        }
                    }

#line 59 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    Set.Apply((Result.Zero, qubits[0L]));
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = ((count - numOnes), numOnes);
                    //Return number of times we saw a |0> and number of times we saw a |1>
#line 62 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
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

    public class BellTest_2 : Operation<(Int64,Result), (Int64,Int64,Int64)>
    {
        public BellTest_2(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.CNOT), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Quantum.Bell.Set) };
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

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get
            {
                return this.Factory.Get<IUnitary<(Qubit,Qubit)>, Microsoft.Quantum.Primitive.CNOT>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
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

        public override Func<(Int64,Result), (Int64,Int64,Int64)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Bell.BellTest_2", OperationFunctor.Body, _args);
                var __result__ = default((Int64,Int64,Int64));
                try
                {
                    var (count,initial) = _args;
                    //If you need a variable whose value can changem such as numOnes, declare the variable with mutable keyword
#line 72 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var numOnes = 0L;
#line 73 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var agree = 0L;
                    // Using statement is also special to Q#. It is used to allocate an array of qubits for use in a block of code.
                    // In Q#, all qubits are dynammically allocated and released, rather than being fixed resources. Using statement allocates a set of qubits at the start 
                    // and releases those qubits at the end of the block
#line 77 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    var qubits = Allocate.Apply(2L);
#line 79 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 81 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        Set.Apply((initial, qubits[0L]));
                        //Added another Set operation to init qubit 1 to make sure it's always in the Zero state when we start
#line 83 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        Set.Apply((Result.Zero, qubits[1L]));
                        //Default, variables in Q# are immutable - their values may not changed after they are boud
                        //The let keyword is used to indicate the binding of an immutable variable
                        // Important operation in Quantum
                        // X : Gate to flip a quabit all the way from 0 to 1 or 1 to 0
                        // H : Hadamard Get flip in halfway it means there is a probabilisty to consider value is 0 or 1
#line 90 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
                        //This will allow us to add a new GAGE CNOT before we measure M in BellTest
#line 92 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        MicrosoftQuantumPrimitiveCNOT.Apply((qubits[0L], qubits[1L]));
#line 93 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        var res = M.Apply<Result>(qubits[0L]);
#line 95 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        if ((M.Apply<Result>(qubits[1L]) == res))
                        {
#line 96 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                            agree = (agree + 1L);
                        }

                        //Count the number of ones we saw:
#line 100 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                        if ((res == Result.One))
                        {
                            //The mutable variable's value can be changed using a set statement
#line 103 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                            numOnes = (numOnes + 1L);
                        }
                    }

#line 106 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    Set.Apply((Result.Zero, qubits[0L]));
                    //Reset the second qubit before releaseing it
#line 108 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    Set.Apply((Result.Zero, qubits[1L]));
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = ((count - numOnes), numOnes, agree);
                    //Return number of times we saw a |0> and number of times we saw a |1>
#line 111 "/Volumes/Develop_Data_MacOS/All_Workspace/Quantum_Computing_Workspace/My_Quantum_Tutorial/Bell/Bell.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Bell.BellTest_2", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Int64,Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest_2, (Int64,Result), (Int64,Int64,Int64)>((count, initial));
        }
    }
}