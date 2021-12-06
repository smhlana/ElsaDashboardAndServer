using Elsa;
using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using Elsa.Attributes;

namespace ElsaQuickstarts.Server.DashboardAndServer.Activities
{
    [Activity(
        Category = "Custom",
        DisplayName = "Suspend Demo",
        Description = "Imagine we have a ReadLine activity that will block until a line is read from the console and fed into the halted workflow.",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class ReadLineActivity : Activity
    {
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            // Instruct the workflow runner to suspend the workflow.
            return Suspend();
        }

        protected override IActivityExecutionResult OnResume(ActivityExecutionContext context)
        {
            // Read received input.
            var receivedInput = context.GetInput<string>();
        
            // Store received input into activity output.
            context.Output = receivedInput;

            // Instruct workflow runner that we're done.
            return Done();
        }
    }
}
