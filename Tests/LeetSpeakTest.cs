using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Services;

namespace Tests
{
    public class LeetSpeakTests
    {
        [Theory]
        [InlineData ("AaeE", "4433")]
        [InlineData ("IIII", "1111")]
        [InlineData ("AaEeIiOoUu", "4433110077")]
        public void ConvertVowelsToNums_StringWithJustVowels_RetunsStringWithRespectiveVowelNumber(string s, string expected)
        {
            Assert.Equal(expected, LeetSpeak.VowelsToNumbers(s));
        }

        [Theory]
        [InlineData ("bbhhhjjjkkkk")]
        [InlineData ("klpyhnbvcdfr")]
        [InlineData ("bllcr")]
        public void ConvertVowelsToNums_StringWithOutAnyVowels_RetunsSameString(string s)
        {
            Assert.Equal(s, LeetSpeak.VowelsToNumbers(s));
        }

        [Theory]
        [InlineData ("Ball Car Spades", "B4ll C4r Sp4d3s")]
        [InlineData ("interesting", "1nt3r3st1ng")]
        [InlineData ("OneAppleADayKeepsTheDocAway", "0n34ppl34D4yK33psTh3D0c4w4y")]
        public void ConvertVowelsToNums_StringWithVowelsAndConsonants_RetunsStringWithRespectiveVowelNumber(string s, string expected)
        {
            Assert.Equal(expected, LeetSpeak.VowelsToNumbers(s));
        }

        [Fact]
        public void ConvertVowelsToNums_EmptyString_ReturnsEmptyString()
        {
            Assert.Empty(LeetSpeak.VowelsToNumbers(""));
        }
    }
}