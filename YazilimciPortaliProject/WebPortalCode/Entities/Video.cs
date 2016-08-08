using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace WebPortalCode.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string Thumb { get; set; }

        public int CatId { get; set; }

        public bool IsAktive { get; set; }
    }
}