using Console_Champions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEF
{
    public class ChampionMemberDataTest
    {
        [Theory]
        [MemberData(nameof(ChampionTestCases.TestCases), MemberType = typeof(ChampionTestCases))]
        public void ChampionShouldHaveExpectedSkins(ChampionEntity champion, List<string> expectedSkins)
        {
            var actualSkins = champion.Skins?.Select(s => s.Name).ToList() ?? new List<string>();
            Assert.Equal(expectedSkins, actualSkins);
        }

        public class ChampionTestCases
        {
            public static IEnumerable<object[]> TestCases()
            {
                yield return new object[] {
                    new ChampionEntity { Skins = new List<SkinEntity> { new SkinEntity { Name = "Classic" }, new SkinEntity { Name = "Sherwood Forest" }, new SkinEntity { Name = "Woad Ashe" } } },
                    new List<string> { "Classic", "Sherwood Forest", "Woad Ashe" }
                };

                yield return new object[] {
                    new ChampionEntity { Skins = new List<SkinEntity> { new SkinEntity { Name = "Classic" }, new SkinEntity { Name = "High Noon" }, new SkinEntity { Name = "Nightbringer Yasuo" }, new SkinEntity { Name = "PROJECT: Yasuo" } } },
                    new List<string> { "Classic", "High Noon", "Nightbringer Yasuo", "PROJECT: Yasuo" }
                };

                yield return new object[] {
                    new ChampionEntity { Skins = new List<SkinEntity> { new SkinEntity { Name = "Classic" } } },
                    new List<string> { "Classic" }
                };
            }
        }

        [Theory]
        [MemberData(nameof(ChampionNameTestCases.TestCases), MemberType = typeof(ChampionNameTestCases))]
        public void ChampionNameShouldBeCorrect(ChampionEntity champion, string expectedName)
        {
            var actualName = champion.Name;
            Assert.Equal(expectedName, actualName);
        }

        public class ChampionNameTestCases
        {
            public static IEnumerable<object[]> TestCases()
            {
                yield return new object[] {
            new ChampionEntity { Name = "Akali" },
            "Akali"
        };

                yield return new object[] {
            new ChampionEntity { Name = "Aatrox" },
            "Aatrox"
        };

                yield return new object[] {
            new ChampionEntity { Name = "Arhi" },
            "Arhi"
        };
            }
        }

        [Theory]
        [MemberData(nameof(ChampionTitleTestCases.TestCases), MemberType = typeof(ChampionTitleTestCases))]
        public void ChampionBioShouldNotBeCorrect(ChampionEntity champion, string expectedTitle)
        {
            var actualTitle = champion.Bio;
            Assert.NotEqual(expectedTitle, actualTitle);
        }

        public class ChampionTitleTestCases
        {
            public static IEnumerable<object[]> TestCases()
            {
                yield return new object[] {
            new ChampionEntity { Bio = "Bio Akali 1" },
            "Bio Akali 2"
        };

                yield return new object[] {
            new ChampionEntity { Bio = "Bio Aatrox 1" },
            "Bio Aatrox 2"
        };

                yield return new object[] {
            new ChampionEntity { Bio = "Bio Arhi 1" },
            "Bio Arhi 2"
        };
            }
        }
    }
}
