using ApiRepository.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using ServicesLibrary;

namespace UnitTestEmployeePortal
{
    [TestClass]
    public class EmployeeServiceTest
    {

        private Mock<EmployeeRepository> employeeRepositoryMock;
        private EmployeeRepository employeeRepository;

        [TestInitialize]
        public void Initialize()
        {
            employeeRepositoryMock = new Mock<EmployeeRepository>();
            employeeRepository = new EmployeeRepository();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var service = new EmployeeService(employeeRepository);
            var id = 1;
            var employee = service.GetEmployee(id);
            //employeeRepositoryMock.Verify(x => x.MakeGetAPICall<IInvocationList> Employee>(It.IsAny<string>()));
            Assert.IsNotNull(employee);
        }

    }
}
