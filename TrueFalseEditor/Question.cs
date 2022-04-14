using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueFalseEditor
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question
    {

        #region Public Properties
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Ответ (да/нет)
        /// </summary>
        public bool TrueFalse { get; set; }

        #endregion

        #region Constructors

        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }

        public Question()
        {

        }

        #endregion

    }
}
