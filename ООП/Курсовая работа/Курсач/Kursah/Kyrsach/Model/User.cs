using System;
using System.Collections.Generic;
using System.ComponentModel;
using NBitcoin;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kyrsach
{
    public partial class User 
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdUser { get; set; }
        public string Mail { get; set; }
        public string Mnemomic { get; set; }
        public bool Admin { get; set; }

    }
}