using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAngularJS.Models
{
    public class UsuarioClass
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int number { get; set; }
        public int citycode { get; set; }
        public int contrycode { get; set; }
    }
}