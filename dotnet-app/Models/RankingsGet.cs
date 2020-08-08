using System;
using Tenanpp.DAL.Models;
using System.Collections.Generic;

namespace Tenanpp.Models{
    public class RankingsGet{
        public List<RankingGeneral> RankingGeneral {get; set;}
        public List<RankingAtencion> RankingAtencion {get; set;}
        public List<RankingConductaEtica> RankingConductaEtica {get; set;}
        public List<RankingResponsabilidad> RankingResponsabilidad {get; set;}
    }
}