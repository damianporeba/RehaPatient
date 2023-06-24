using Moq;
using RehaPatient;
using RehaPatient.App.Abstract;
using RehaPatient.App.Common;
using RehaPatient.App.Concrete;
using RehaPatient.App.Manage;
using RehaPatient.Domain.Entity;
using Xunit;

namespace RehaPatient.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetPatientByPesel()

        {
            //Arrange
            Patient patient = new Patient(1, "Damian", "Poreba", "98082411272", "M54");


            var mock = new Mock<IService<Patient>>();

            mock.Setup(s => s.GetPatientByPesel("98082411272")).Returns(patient);
            var manager = new PatientManager(new MenuActionService(), mock.Object);


            //Act

            var returnerPesel = manager.GetPatientByPesel(patient.Pesel);

            //Assert

            Assert.Equal(patient, returnerPesel);
        }




    }

    public class UnitTest2
    {
        [Fact]
        public void YearsNow()
        {
            //Arrange
            Patient patient = new Patient(1, "Damian", "Poreba", "98082411272", "M54") { Age = "24.08.1998" };

            BaseService<Patient> baseService = new BaseService<Patient>();



            //Act
            var age = baseService.GetAgeByPesel(patient.Pesel);


            //Assert

            Assert.Equal(age, patient.Age);

        }
    }

    public class UnitTest3
    {
        [Fact]
        public void GetAgeByPesel()
        {
            //Arrange
            Patient patient = new Patient(1, "Damian", "Poreba", "98082411272", "M54") { Age = "24.08.1998", YearsNow = 25 };

            BaseService<Patient> baseService = new BaseService<Patient>();

            //Act
            var patientYearsNow = baseService.PatientAge(patient.Age);


            //Assert

            Assert.Equal(patient.YearsNow, patientYearsNow);

        }
    }

    public class UnitTest4
    {
        [Fact]
        public void AddPatient()
        {
            //Arrange
            //Act
            //Assert
        }



    }
    public class UnitTest5
    {
        [Fact]
        public void RemovePatient()
        {
            //Arrange
            //Act
            //Assert
        }



    }

}