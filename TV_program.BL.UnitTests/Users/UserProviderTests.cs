using System.Linq.Expressions;
using TV_program.BL.UnitTest.Mapper;
using TV_program.DataAccess.Entities;
using TV_program.DataAccess;
using Moq;
using TV_program.BL.Users;
using TV_program.BL.UnitTests.Mapper;

namespace TV_program.BL.UnitTests.Users
{
    [TestFixture]
    public class UserProviderTests
    {
        [Test]
        public void testGetAllUsers()
        {
            Expression expression = null;
            Mock<IRepository<UserEntity>> usersRepository = new Mock<IRepository<UserEntity>>();
            usersRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .Callback((Expression<Func<UserEntity, bool>> x) => { expression = x; });
            var usersProvider = new UsersProvider(usersRepository.Object, MapperHelper.Mapper);
            var users = usersProvider.GetUsers();

            usersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()), Times.Exactly(1));

        }
    }
}
