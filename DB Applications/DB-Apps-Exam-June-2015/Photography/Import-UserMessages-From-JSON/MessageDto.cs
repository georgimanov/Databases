using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Import_UserMessages_From_JSON
{
    public class MessageDto
    {
        public string Content { get; set; }

        public string Datetime { get; set; }

        public string Recipient { get; set; }

        public string Sender { get; set; }

    }
}
