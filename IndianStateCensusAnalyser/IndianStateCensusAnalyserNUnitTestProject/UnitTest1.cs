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
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFile = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\WrongHeaderIndiaStateCensusData.csv";
        static string IncorrectIndianStateCensusFileName = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData1.csv";
        static string CorrectIndianStateCensusFileButTypeIncorrect = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData.txt";
        static string wrongDelimiterIndianCensusFilePath = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\DelimiterIndiaStateCensusData.csv";

        static string indiaStateCodeFilePath = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCode.csv";
        static string wrongHeaderIndiaStateCodeFile = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\WrongHeaderIndiaStateCode.csv";
        static string IncorrectIndiaStateCodeFileName = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCode1.csv";
        static string CorrectIndiaStateCodeFileButTypeIncorrect = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCode.txt";
        static string wrongDelimiterIndiaStateCodeFilePath = @"E:\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\DelimiterIndiaStateCode.csv";

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

        [Test]  //TC2.1
        public void GivenIndianStateCodeFileData_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indiaStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(2, totalRecord.Count);

        }
        [Test]  //TC2.2
        public void GivenIncorrectIndiaStateCodeFileName_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IncorrectIndiaStateCodeFileName, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        [Test]  //TC2.3
        public void GivenCorrectIndianStateCodeFileName_But_Extension_Incorrect_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CorrectIndiaStateCodeFileButTypeIncorrect, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]  //TC2.4
        public void GivenDelimiterInorrectIndiaStateCodeFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndiaStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]  //TC2.5
        public void GivenWrongHeaderIndianStateCode_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndiaStateCodeFile, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }



    }
}