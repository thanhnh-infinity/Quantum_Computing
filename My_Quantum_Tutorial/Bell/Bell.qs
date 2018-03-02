namespace Quantum.Bell
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;
    //This operation may now be called to set a qubit in a known state (Zero or One)
    //We measure the qubit, if it is in the state we want, we leave it alone, otherwise we flop it to X gate
    operation Set (desired : Result, q1 : Qubit) : ()
    {
        body
        {
            let current = M(q1);
            if (desired != current)
            {
                X(q1);
            }
        }
    }
    //This operation will loop for count iterations. set a specified initial value on a qubit and them measure M result
    //It will gather statistisc\cs on how many zeros and ones we've measured and return them to the caller.

    //All of these calls use primitive quantum operations that are defined in the Microsoft.Quantum.Primitive namespace
    //The M operation measures its argument qubit in the computational  Z basics and X applies a state flip around the x axis to its argument qubit

    //Q# does not require any type annotations for variables
    //BellTest operation returns 2 values as a tuple. Q# uses tuples as a way to pass multiple values rather than using structures or records
    operation BellTest(count : Int,initial : Result) : (Int,Int)
    {
        body
        {
            //If you need a variable whose value can changem such as numOnes, declare the variable with mutable keyword
            mutable numOnes = 0;

            // Using statement is also special to Q#. It is used to allocate an array of qubits for use in a block of code.
            // In Q#, all qubits are dynammically allocated and released, rather than being fixed resources. Using statement allocates a set of qubits at the start 
            // and releases those qubits at the end of the block
            using (qubits = Qubit[1])
            {
                for (test in 1..count)
                {
                    Set(initial,qubits[0]);
                    //Default, variables in Q# are immutable - their values may not changed after they are boud
                    //The let keyword is used to indicate the binding of an immutable variable

                    // Important operation in Quantum
                    // X : Gate to flip a quabit all the way from 0 to 1 or 1 to 0
                    // H : Hadamard Get flip in halfway it means there is a probabilisty to consider value is 0 or 1. Such as 63% is 0 and 37% is 1
                    // ===> this is SUPERPOSITION 
                    // Everytime we measure we ask for a classical value but the qubit is halfway between 0 and 1, so we get probabilistuc 0 half and 1half time.
                    H(qubits[0]);
                    let res = M(qubits[0]);

                    //Count the number of ones we saw:
                    if (res == One)
                    {
                        //The mutable variable's value can be changed using a set statement
                        set numOnes = numOnes + 1;
                    }
                }
                Set(Zero,qubits[0]);
            }
            //Return number of times we saw a |0> and number of times we saw a |1>
            return (count - numOnes,numOnes);
        }
    }
    
    // BellTest 2 will introduce about ENTANGLEMENT in Quantum Computing
    operation BellTest_2(count : Int,initial : Result) : (Int,Int,Int)
    {
        body
        {
            //If you need a variable whose value can changem such as numOnes, declare the variable with mutable keyword
            mutable numOnes = 0;
            mutable agree = 0;
            // Using statement is also special to Q#. It is used to allocate an array of qubits for use in a block of code.
            // In Q#, all qubits are dynammically allocated and released, rather than being fixed resources. Using statement allocates a set of qubits at the start 
            // and releases those qubits at the end of the block
            using (qubits = Qubit[2])
            {
                for (test in 1..count)
                {
                    Set(initial,qubits[0]);
                    //Added another Set operation to init qubit 1 to make sure it's always in the Zero state when we start
                    Set(Zero,qubits[1]);
                    //Default, variables in Q# are immutable - their values may not changed after they are boud
                    //The let keyword is used to indicate the binding of an immutable variable

                    // Important operation in Quantum
                    // X : Gate to flip a quabit all the way from 0 to 1 or 1 to 0
                    // H : Hadamard Get flip in halfway it means there is a probabilisty to consider value is 0 or 1
                    H(qubits[0]);
                    //This will allow us to add a new GAGE CNOT before we measure M in BellTest
                    CNOT(qubits[0],qubits[1]);
                    let res = M(qubits[0]);

                    if (M(qubits[1]) == res){
                       set agree = agree + 1;
                    }

                    //Count the number of ones we saw:
                    if (res == One)
                    {
                        //The mutable variable's value can be changed using a set statement
                        set numOnes = numOnes + 1;
                    }
                }
                Set(Zero,qubits[0]);
                //Reset the second qubit before releaseing it
                Set(Zero,qubits[1]);
            }
            //Return number of times we saw a |0> and number of times we saw a |1>
            //There is not a new return value agree that will keep track of everythime the measurement from the first qubit matches the measurements of the secod qubit.
            return (count - numOnes,numOnes,agree);
        }
    }
}
