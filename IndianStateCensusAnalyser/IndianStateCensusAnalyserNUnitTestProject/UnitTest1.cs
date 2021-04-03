using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserNUnitTestProject
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFile = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\WrongHeaderIndiaStateCensusData.csv";
        static string IncorrectIndianStateCensusFileName = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData1.csv";
        static string CorrectIndianStateCensusFileButTypeIncorrect = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData.txt";
        static string wrongDelimiterIndianCensusFilePath = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\DelimiterIndiaStateCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]  //TC1.1
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);

        }
        [Test]  //TC1.2
        public void GivenIncorrectIndianCensusDataFileName_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IncorrectIndianStateCensusFileName, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        [Test]  //TC1.3
        public void GivenCorrectIndianCensusDataFileName_But_Extension_Incorrect_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CorrectIndianStateCensusFileButTypeIncorrect, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]  //TC1.4
        public void GivenDelimiterInorrectIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]  //TC1.5
        public void GivenWrongHeaderIndianStateCensusData_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFile, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }


    }
}