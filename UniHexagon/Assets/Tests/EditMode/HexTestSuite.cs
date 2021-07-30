using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using UniHexagon;
using UniHexagon.Hexes;
using UniHexagon.Interfaces;
using UnityEngine;

namespace Tests.HexGrid
{
    [TestFixture]
    internal sealed class HexTestSuite
    {
        private sealed class HexTests
        {
            private readonly AbstractHexFactory _hexFactory = new HexFactory();
            private IHex _hex;
            private IHex _secondaryHex;

            [SetUp]
            public void Setup_Hex()
            {
                _hex = _hexFactory.Produce(new Vector2Int(0, 0));
            }

            [Test]
            public void Equate_EqualHexes_ShouldBeEqual()
            {
                _secondaryHex = _hexFactory.Produce(new Vector2Int(0, 0));

                _hex.Should().Be(_secondaryHex);
            }

            [Test]
            public void Equate_UnequalHexes_ShouldNotBeEqual()
            {
                _secondaryHex = _hexFactory.Produce(new Vector2Int(1, 1));

                _hex.Should().NotBe(_secondaryHex);
            }

            [Test]
            public void GetNeighbors_OfNewHex_ShouldMatchExpectedNeighbors()
            {
                // Generates expected neighbors by creating a hex at every direction around original hex
                var expectedNeighbors =
                    _hex.Directions.Select(direction => _hexFactory.Produce(direction));

                _hex.GetNeighbors().Should().Equal(expectedNeighbors);
            }
            
            [Test]
            public void GetOppositeSideOf_RightSide_ShouldBeLeftSide()
            {
                _hex.GetOppositeSideOf((int) PointyHexSide.Right).Should().Be((int) PointyHexSide.Left);
            }
            
            [Test]
            public void GetNeighborAtDirection_OfNewHex_ShouldMatchExpectedNeighbor()
            {
                IHex expectedNeighbor = _hexFactory.Produce(new Vector2Int(1, -1));
                
                _hex.GetNeighborAtDirection(0).Should().Be(expectedNeighbor);
            }
        }

        private sealed class HexMapTests
        {
            private readonly AbstractHexMapFactory _hexMapFactory = new HexMapFactory();
            private IHexMap _hexMap;

            [SetUp]
            public void Setup_HexGrid()
            {
                _hexMap = _hexMapFactory.Produce();
            }

            [Test]
            public void Create_NewGrid_NoHexIsNull()
            {
                _hexMap.Create(1);

                _hexMap.Hexes.Should().NotContainNulls();
            }

            [Test]
            public void Create_NewGrid_AllHexesAreUnique()
            {
                _hexMap.Create(2);

                _hexMap.Hexes.Should().OnlyHaveUniqueItems();
            }

            [Test]
            public void Create_NewGrid_AllHexesHaveNeighbors()
            {
                _hexMap.Create(2);

                // Get the reported neighbors of every hex
                var reportedNeighbors = _hexMap.Hexes.Select(hex => hex.GetNeighbors());

                // Check at least one neighbor of every hex actually exists in the map
                reportedNeighbors.All(neighbors => _hexMap.Hexes.Overlaps(neighbors)).Should().BeTrue();
            }

            [Test]
            public void Create_NewGrid_CreatesProperAmount()
            {
                _hexMap.Create(1);

                _hexMap.Hexes.Should().HaveCount(1);
            }
            
            [Test]
            public void GetValidNeighborsOf_LoneHex_ShouldGetNone()
            {
                _hexMap.Create(1);

                _hexMap.GetValidNeighborsOf(_hexMap.Hexes.First()).Should().BeEmpty();
            }

            [TearDown]
            public void Teardown_HexGrid()
            {
                _hexMap.Clear();
            }
        }
    }
}