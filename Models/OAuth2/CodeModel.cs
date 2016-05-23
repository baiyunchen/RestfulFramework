using System;

namespace Models
{
   public class CodeModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Appid { get; set; }
        public int ExpiresIn { get; set; }

    }
}
