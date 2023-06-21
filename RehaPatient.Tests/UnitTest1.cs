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
        public void RemovePatient() 

        {
            //Arrange
            Patient patient = new Patient(1, "Damian", "Poreba", "98082411272", "M54");

            
            var mock = new Mock <IService<Patient>>();
            
            mock.Setup(s => s.GetPatientByPesel("98082411272")).Returns(patient);
            var manager = new PatientManager(new MenuActionService(), mock.Object);
            

            //Act

            var returnerPesel = manager.GetPatientByPesel(patient.Pesel);

            //Assert

            Assert.Equal(patient, returnerPesel);   
        }


       
    }
}