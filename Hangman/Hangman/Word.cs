using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Word
    {
        private string _content;
        public Word(string content)
        {
            this._content = content;
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public int Wordlength
        { 
            get { return this._content.Length; }
        }
    }
    
}
