﻿using PaymentContext.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CommandBoletoPaymentSubscription : CommandPaymentSubscription
    {
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
    }
}
