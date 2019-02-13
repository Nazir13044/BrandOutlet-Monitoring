using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCMS_MAIN.Models
{
    public class MenuModel
    {
        public string MainMenuName { get; set; }
        public long MainMenuId { get; set; }
        public string SubMenuName { get; set; }
        public long SubMenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public long? RoleId { get; set; }
        public string RoleName { get; set; }
    }
}