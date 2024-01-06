using System;
using System.Collections.Generic;
using System.Text;

namespace TopLearn.Core.Generate
{
    public class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
