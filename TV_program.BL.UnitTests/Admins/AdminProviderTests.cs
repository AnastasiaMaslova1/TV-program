using System.Linq.Expressions;
using TV_program.BL.Admins;
using TV_program.BL.UnitTest.Mapper;
using TV_program.DataAccess;
using TV_program.DataAccess.Entities;
using Moq;
using NUnit.Framework;
using TV_program.BL.UnitTests.Mapper;

namespace TV_program.BL.UnitTests.Admins
{
    public class AdminProviderTests
    {
        [Test]
        public void testGetAllAdmins()
        {
            Expression expression = null;
            Mock<IRepository<AdminEntity>> adminsRepository = new Mock<IRepository<AdminEntity>>();
            adminsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<AdminEntity, bool>>>()))
                .Callback((Expression<Func<AdminEntity, bool>> x) => { expression = x; });
            var adminsProvider = new AdminsProvider(adminsRepository.Object, MapperHelper.Mapper);
            var admins = adminsProvider.GetAdmins();

            adminsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<AdminEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
