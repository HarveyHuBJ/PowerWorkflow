namespace PowerWorkflow.Enums
{
    public enum PowerThreadState
    {
        Initial = 1,  // intialized, but not assign user into roles and no statemachine(criteria for node transmitting)
        Start = 2,    // with users and statemachine
        Processing = 3,
        End = 9,
        Terminated = 11,
        Paused = 21,
        Unknown = 99
    }
}