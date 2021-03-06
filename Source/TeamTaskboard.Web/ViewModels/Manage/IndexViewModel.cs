﻿namespace TeamTaskboard.Web.ViewModels.Manage
{
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;

    public class IndexViewModel
    {
        public string Id { get; set; }
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }
}