using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class AccountTypeModel
    {
        public int AccountTypeId { get; set; }
        public string AccountTyp { get; set; }
        public double? MinBalance { get; set; }
        public int? Interest { get; set; }
        public int? TransactionLimit { get; set; }
    }
}
