using System;
using System.IO;
using System.Threading.Tasks;
using Elsa;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;

namespace ElsaQuickstarts.Server.DashboardAndServer.Activities
{
    [Activity(
        Category = "Custom",
        DisplayName = "Write Line Demo",
        Description = "Write text to standard out.",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class SayHelloWorldActivity : Activity
    {
        private readonly TextWriter _textWriter;
        public SayHelloWorldActivity(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        [ActivityInput(Hint = "The message to write.")]
        public string Message { get; set; }

        protected override async ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
        {
            var random = new Random();
            var outcomeName = string.Empty;

            if (random.Next(10) % 2 == 0)
            {
                outcomeName = "Success";
            }
            else 
            {
                outcomeName = "Failed";
            }

            await _textWriter.WriteLineAsync($"{Message}\nOutcome: {outcomeName}");

            return Outcome(outcomeName);
        }
    }
}
