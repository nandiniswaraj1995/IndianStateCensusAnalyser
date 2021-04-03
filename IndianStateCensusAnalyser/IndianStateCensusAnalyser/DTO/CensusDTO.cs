using IndianStateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.DTO
{
    public class CensusDTO
    {
        private string state;
        private long population;
        private long area;
        private long density;
       
        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }

    }
}