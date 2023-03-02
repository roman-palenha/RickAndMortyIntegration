using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace RickAndMortyIntegration.Business.Validation
{
    public class RickAndMortyException : Exception
    {
        public RickAndMortyException() 
        {
        }

        public RickAndMortyException(string message) 
            : base(message) 
        {
        }

        public RickAndMortyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
