using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CommandResult: ICommandResult
    {
        public CommandResult(bool success, string? message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; private set; }
        public string? Message { get; private set; }
    }
}
