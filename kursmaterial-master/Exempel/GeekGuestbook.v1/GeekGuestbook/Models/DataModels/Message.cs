//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeekGuestbook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int MessageId { get; set; }
        public System.DateTime Created { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
