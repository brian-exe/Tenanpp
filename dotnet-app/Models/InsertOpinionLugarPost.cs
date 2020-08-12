using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tenanpp.Models{
    public class InsertOpinionLugarPost{
        public LugarPost lugar {get; set;}
        public OpinionLugarPost opinion {get; set;}
    }
}