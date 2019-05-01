using System;
using System.IO;
using Xunit;
using NameSearchCore;
using System.Linq;

namespace NameSearchTest
{
    public class UnitTest
    {
        [Fact]
        public void SaveFileTest()
        {
            int randomNumber = new Random().Next();
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sr = new StreamWriter(ms))
            {
               
                sr.WriteLine(randomNumber);
               
                sr.Flush();
                ms.Position = 0;
                NameSearchCore.Utilities.SaveFile(ms, "test.txt").Wait();
                
            }

            Assert.True(File.Exists("test.txt"));

            var lines = File.ReadLines("test.txt").ToList();

            Assert.True(lines.Count() == 1);
            Assert.Equal(randomNumber.ToString(), lines[0]);
        }
    }
}
