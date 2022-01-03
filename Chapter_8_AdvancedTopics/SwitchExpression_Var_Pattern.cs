using System;

class SwitchExpression_Var_Pattern
{
    public static void Main()
    {

        // A special form of type pattern matching is using var. 

    }
    public void ExecuteCommand(string command)
    {

        switch (command)
        {

            case "add": break;
            case "del": break;
            case "exit": break;

            case var o when (o?.Length ?? 0) == 0:
                // do nothing
                /*
                    This function tries to match the add, del, and exit commands and execute them
                    appropriately. However, if the argument is null or empty or has only white spaces, it
                    will do nothing. But this is a different case than an actual command that is either not
                    supported or not recognized. The var pattern match helps to differentiate between the
                    two in a simple and elegant manner.
                */
                break;

            default:
                // invalid command
                break;
        }
    }
}