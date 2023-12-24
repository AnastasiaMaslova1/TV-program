using System.Linq.Expressions;
using TV_program.BL.UnitTest.Mapper;
using TV_program.DataAccess.Entities;
using TV_program.DataAccess;
using Moq;
using TV_program.BL.TVShow;
using TV_program.BL.UnitTests.Mapper;

namespace TV_program.BL.UnitTests.TVShow
{
    [TestFixture]
    public class TVShowProviderTests
    {
        [Test]
        public void testGetAllTVShow()
        {
            Expression expression = null;
            Mock<IRepository<TVShowEntity>> showsRepository = new Mock<IRepository<TVShowEntity>>();
            showsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<TVShowEntity, bool>>>()))
                .Callback((Expression<Func<TVShowEntity, bool>> x) => { expression = x; });
            var showsProvider = new TVShowProvider(showsRepository.Object, MapperHelper.Mapper);
            var shows = showsProvider.GetTVShow();

            showsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<TVShowEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
