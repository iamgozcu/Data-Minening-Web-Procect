//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Kisiler
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alan gereklidir")]
        public Nullable<int> OkulID { get; set; }
        [Required(ErrorMessage ="{0} alan gereklidir")]
        [DisplayName("Okul No")]
        public string OkulNo { get; set; }
    
        public virtual OkulBlg OkulBlg { get; set; }
    }
}
